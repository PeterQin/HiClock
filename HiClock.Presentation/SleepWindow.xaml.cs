using HiClock.Application.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using HiClock.Domain;
using System.Threading;
using HiClock.WinForm;
using System.Reflection;
using System.Waf.Applications;
using HiClock.Application;
using Common.Foundation;

namespace HiClock.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export(typeof(ISleepView)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public partial class SleepWindow : Window, ISleepView
    {
        public string WebSource
        {
            get { return (string)GetValue(WebSourceProperty); }
            set { SetValue(WebSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WebSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WebSourceProperty =
            DependencyProperty.Register("WebSource", typeof(string), typeof(SleepWindow), new PropertyMetadata("about:blank", WebSource_PropChanged));

        private static void WebSource_PropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SleepWindow window = d as SleepWindow;
            if (window != null)
            {
                if (window.TurnOnRadio)
                {
                    window.browser.Source = window.FormatURL(e.NewValue.ToString());
                }
                else
                {
                    window.browser.Source = new Uri("about:blank");
                }
            }
        }
      
        public bool TurnOnRadio
        {
            get { return (bool)GetValue(TurnOnRadioProperty); }
            set { SetValue(TurnOnRadioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TurnOnRadio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TurnOnRadioProperty =
            DependencyProperty.Register("TurnOnRadio", typeof(bool), typeof(SleepWindow), new PropertyMetadata(false, TurnOnRadio_PropChanged));

        private static void TurnOnRadio_PropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SleepWindow window = d as SleepWindow;
            if (window != null)
            {
                if ((bool)e.NewValue)
                {
                    window.browser.Source = window.FormatURL(window.WebSource);
                }
                else
                {
                    window.browser.Source = new Uri("about:blank");
                }
            }
        }
                
        public HiClockRoot Root
        {
            get { return (HiClockRoot)GetValue(RootProperty); }
            set { SetValue(RootProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Root.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RootProperty =
            DependencyProperty.Register("Root", typeof(HiClockRoot), typeof(SleepWindow), new PropertyMetadata(null, Root_PropertyChanged));

        private static void Root_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SleepWindow win = d as SleepWindow;
            if (win != null)
            {
                win.InitTimer();
            }
        }

        private DispatcherTimer FRefreshTimer = new DispatcherTimer();

        [ImportingConstructor]
        public SleepWindow()
        {
            InitializeComponent();            
            Initialize();
        }

        private void Initialize()
        {
            this.SetBinding(TurnOnRadioProperty, new Binding("Root.TurnOnRadio") { Mode = BindingMode.OneWay });
            this.SetBinding(WebSourceProperty, new Binding("Root.RadioUri") { Mode = BindingMode.OneWay });
            this.SetBinding(RootProperty, new Binding("Root") { Mode = BindingMode.OneWay });

            this.PreviewKeyUp += SleepWindow_PreviewKeyUp;
            this.Left = 0;
            this.Top = 0;
            this.Height = WinForm.WinFormHelper.Instance.GetScreenMaxHeight();
            this.Width = WinForm.WinFormHelper.Instance.GetScreenWidthSum();
            this.gridMain.Width = WinForm.WinFormHelper.Instance.GetMainScreenWidth();

            
        }

        public void InitTimer()
        {
            if (Root != null && Root.ImageList.HasElement())
            {
                FRefreshTimer.Stop();
                FRefreshTimer.Interval = HiClock.Application.Util.Instance.FormatFrequency(Root.RefreshScreenFrequency);
                FRefreshTimer.Tick += FRefreshTimer_Tick;
                FRefreshTimer.Start();
                NextPicture();
            }
        }

        private void FRefreshTimer_Tick(object sender, EventArgs e)
        {
            NextPicture();
        }

        private void NextPicture()
        {
            if (Root != null && Root.ImageList.HasElement())
            {
                if (Root.CurrentImageIndex == Root.ImageList.Count - 1)
                {
                    Root.CurrentImageIndex = 0;
                }
                else
                {
                    Root.CurrentImageIndex += 1;
                }
                img.Source = GetImage(Root.ImageList[Root.CurrentImageIndex].FullName);
            }
        }

        private BitmapImage GetImage(string aPath)
        {
            if (aPath == null || string.IsNullOrWhiteSpace(aPath))
            {
                return null;
            }

            BitmapImage result = new BitmapImage();
            result.BeginInit();
            try
            {
                result.UriSource = new Uri(aPath, UriKind.Relative);
                result.CacheOption = BitmapCacheOption.OnLoad;
            }
            finally
            {
                result.EndInit();
            }
            return result;
        }

        protected Uri FormatURL(string aUriString)
        {
            Uri uri;
            if (Uri.TryCreate(aUriString, UriKind.Absolute, out uri) == false)
            {
                uri = new Uri(Uri.UriSchemeHttp + Uri.SchemeDelimiter + aUriString);
            }
            return uri;
        }

        private void SleepWindow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();  
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.PreviewKeyUp -= SleepWindow_PreviewKeyUp;
            if (System.Windows.Interop.ComponentDispatcher.IsThreadModal)
            {
                this.DialogResult = true;
            }
            FRefreshTimer.Tick -= FRefreshTimer_Tick;
            FRefreshTimer.Stop();
            TurnOnRadio = false;
        }

        #region Catch WebBrowser Error

        private bool FIsWebBrowserSilent;

        private bool IsWebBrowserSilent
        {
            get { return FIsWebBrowserSilent; }
            set
            {
                if (FIsWebBrowserSilent != value)
                {
                    FIsWebBrowserSilent = value;
                    SetWebBrowserSilent(browser, value);
                }
            }
        }

        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasError.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(SleepWindow), new PropertyMetadata(false));

        public bool IsNavigating
        {
            get { return (bool)GetValue(IsNavigatingProperty); }
            set { SetValue(IsNavigatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsNavigating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsNavigatingProperty =
            DependencyProperty.Register("IsNavigating", typeof(bool), typeof(SleepWindow), new PropertyMetadata(false));


        private void SetWebBrowserSilent(WebBrowser aWebBrowser, bool aSilent)
        {
            FieldInfo fi = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fi != null)
            {
                object browser = fi.GetValue(aWebBrowser);
                if (browser != null)
                {
                    browser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, browser, new object[] { aSilent });
                }
            }
        } 

        private void browser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            IsNavigating = true;
            IsWebBrowserSilent = false;
            HasError = false;
        }

        private void browser_Navigated(object sender, NavigationEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            if (browser != null)
            {
                CatchHTMLError(browser);
            }
        }

        /// <summary>
        /// To catch script error
        /// </summary>
        /// <param name="web"></param>
        private void CatchHTMLError(WebBrowser web)
        {
            mshtml.HTMLDocument document = web.Document as mshtml.HTMLDocument;
            mshtml.IHTMLWindow2 window = document.parentWindow;
            mshtml.HTMLWindowEvents_Event windowEvents = window as mshtml.HTMLWindowEvents_Event;
            windowEvents.onerror -= new mshtml.HTMLWindowEvents_onerrorEventHandler(windowEvents_onerror);
            windowEvents.onerror += new mshtml.HTMLWindowEvents_onerrorEventHandler(windowEvents_onerror);
        }

        private void windowEvents_onerror(string description, string url, int line)
        {
            HasError = true;
            IsWebBrowserSilent = true;
        }

        #endregion Catch WebBrowser Error

    }
}
