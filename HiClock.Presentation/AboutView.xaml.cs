using HiClock.Application.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.Business;

namespace HiClock.Presentation
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    [Export(typeof(IAboutView)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    internal partial class AboutView : UserControl, IAboutView
    {
        public AboutView()
        {
            InitializeComponent();

        }

        private const string C_SupportEmail = "Peter_Qin@live.com";

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            string errInfo;
            TMapiEmail email = new TMapiEmail();
            email.Logon(IntPtr.Zero);
            email.AddRecip(C_SupportEmail, null, false);
            bool SentSuccess = email.Send(string.Empty, string.Empty, out errInfo);
            email.Logoff();
            if (SentSuccess == false)
            {
                MessageBox.Show("This email cannot be sent because " + errInfo, "Email", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void miCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(C_SupportEmail);
        }
    }
}
