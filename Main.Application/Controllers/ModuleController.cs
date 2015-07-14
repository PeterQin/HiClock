using Common.Application.Services;
using Main.Application.Properties;
using Main.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;
using System.Windows.Threading;

namespace Main.Application.Controllers
{
    [Export(typeof(IModuleController)), Export]
    internal class ModuleController : Controller, IModuleController
    {
        private readonly ShellViewModel FShellViewModel;     

        [ImportingConstructor]
        public ModuleController(ShellViewModel shellViewModel)
        {
            FShellViewModel = shellViewModel;            
        }

        public void Initialize()
        {          
        }      

        public void Run()
        {           
            //FShellViewModel.Value.Show();
        }

        public void Shutdown()
        {
            try
            {                
                Settings.Default.Save();
            }
            catch (Exception)
            {
                // When more application instances are closed at the same time then an exception occurs.
            }
        }
    }
}
