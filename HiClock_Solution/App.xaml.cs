using Common.Application.Services;
using Common.Presentation.Views;
using HiClock_Solution.Properties;
using Microsoft.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf;
using System.Waf.Applications;
using System.Windows;
using System.Windows.Threading;

namespace HiClock_Solution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        private AggregateCatalog catalog;
        private CompositionContainer container;
        private IEnumerable<IModuleController> moduleControllers;

        static App()
        {
#if (DEBUG)
            WafConfiguration.Debug = true;
#endif
        }

        private const string Unique = "HiClock_{828331D0-E10F-4127-8AD8-9CF2E76EECBD}";
        [STAThread]
        public static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                var application = new App();
                application.InitializeComponent();
                application.Run();
                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }
        #region ISingleInstanceApp Members
        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            // handle command line arguments of second instance
            // ...
            return true;
        }
        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

#if (DEBUG != true)
            // Don't handle the exceptions in Debug mode because otherwise the Debugger wouldn't
            // jump into the code when an exception occurs.
            DispatcherUnhandledException += AppDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            //Dispatcher.UnhandledException += Dispatcher_UnhandledException;
#endif

            catalog = new AggregateCatalog();
            // Add the WpfApplicationFramework assembly to the catalog
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Controller).Assembly));

            string workingFolder = AppDomain.CurrentDomain.BaseDirectory;
            // Load module assemblies as well. See App.config file.
            foreach (string moduleAssembly in Settings.Default.ModuleAssemblies)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(Path.Combine(workingFolder, moduleAssembly)));
            }

            container = new CompositionContainer(catalog);
            CompositionBatch batch = new CompositionBatch();
            batch.AddExportedValue(container);
            container.Compose(batch);

            // Initialize all presentation services
            var presentationServices = container.GetExportedValues<IPresentationService>();
            foreach (var presentationService in presentationServices) { presentationService.Initialize(); }

            // Initialize and run all module controllers
            moduleControllers = container.GetExportedValues<IModuleController>();
            foreach (var moduleController in moduleControllers) { moduleController.Initialize(); }
            foreach (var moduleController in moduleControllers) { moduleController.Run(); }
        }

        protected void InitFont()
        {
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            foreach (var moduleController in moduleControllers.Reverse()) { moduleController.Shutdown(); }
            container.Dispose();
            catalog.Dispose();

            base.OnExit(e);
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception, false);
            e.Handled = true;
        }


        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception, false);
            e.Handled = true;
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception, e.IsTerminating);
        }

        private static void HandleException(Exception e, bool isTerminating)
        {
            if (e == null) { return; }

            Trace.TraceError(e.ToString());
            
            if (!isTerminating)
            {
                //MessageBox.Show(string.Format(CultureInfo.CurrentCulture, "Unknown application error\n\n{0}", e.ToString()), ApplicationInfo.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
                SupportWindow window = new SupportWindow();
                window.ErrorMessage = e.Message;
                StringBuilder sb = GetTraceStack(e);
                window.TraceStack = sb.ToString();
                window.ShowDialog();
            }
        }

        private static StringBuilder GetTraceStack(Exception ex)
        {
            StringBuilder result = new StringBuilder();
            if (ex.InnerException != null)
            {
                result.Append(GetTraceStack(ex.InnerException));
            }
            result.Append(Environment.NewLine);
            result.Append("-- " + ex.Message + "  --");
            result.Append(Environment.NewLine);
            result.Append(ex.Message);
            result.Append(Environment.NewLine);
            result.Append(ex.StackTrace);
            result.Append(Environment.NewLine);
            result.Append("--------");
            return result;
        }
    }
}
