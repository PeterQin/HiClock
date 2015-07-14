using Common.Business;
using Common.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Common.Presentation.Views
{
    /// <summary>
    /// Interaction logic for SupportWindow.xaml
    /// </summary>
    public partial class SupportWindow : Window
    {
        #region Field

        Thread FSendingEmailThread;

        #region Const / Enum / Delegate / Event

        private const string C_GetMachineInfo_OSVersion = "Operation System Version: {0}";
        private const string C_GetMachineInfo_Version = "Common Language Version: {0}";
        private const string C_Application_Version = "Product Version: {0}";
        private const string C_Application_Name = "Product: {0}";
        private const string C_Exception_Detail = "Exception Detail: {0}";
        private const string C_Exception_At = "Exception Date: {0}";
        private const string C_SupportInfoFile = "SupportInfo.txt";

        #endregion Const / Enum / Delegate / Event

        #region Property

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(SupportWindow), new PropertyMetadata(string.Empty));

        public string TraceStack
        {
            get { return (string)GetValue(TraceStackProperty); }
            set { SetValue(TraceStackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TraceStack.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TraceStackProperty =
            DependencyProperty.Register("TraceStack", typeof(string), typeof(SupportWindow), new PropertyMetadata(string.Empty));


        private bool FIsSending = false;

        public bool IsSending
        {
            get { return FIsSending; }
            set
            {
                if (FIsSending != value)
                {
                    FIsSending = value;
                    UpdateUISynchronize();
                }
            }
        }

        public string SupportInfoPath
        {
            get
            {
                return System.IO.Path.Combine(Util.GetDataDirectory(), C_SupportInfoFile);                
            }
        }

        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public SupportWindow()
        {
            InitializeComponent();
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private void Init()
        {
            IsSending = false;
            if (File.Exists(SupportInfoPath))
            {
                txtMail.Text = File.ReadAllText(SupportInfoPath);
            }
            txtSubject.Text = "[HiClock] Exception - " + ErrorMessage;
            txtSupport.Text = rcSupport.SupportEmail;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetAppInfo());
            sb.AppendLine(GetMachineInfo());
            sb.AppendLine(string.Format(C_Exception_At, DateTime.Now));
            sb.AppendLine(GetTraceStack());
            txtMailContent.Text = sb.ToString();
            Endisable();
        }

        private string GetTraceStack()
        {
            return string.Format(C_Exception_Detail, TraceStack);
        }

        private void SendEmail(object aObj)
        {
            EmailInfo info = aObj as EmailInfo;
            bool result = false;
            try
            {
                if (info != null)
                {
                    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                    message.To.Add(info.To);
                    message.Subject = info.Subject;
                    message.From = new System.Net.Mail.MailAddress(info.From);
                    message.Body = info.Body;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential(info.ProxyName, info.ProxyPwd);
                    smtp.Send(message);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail to send email", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }
            finally
            {
                IsSending = false;
                ClaseSync(result);
            }
        }

        private void ClaseSync(bool aResult)
        {
            this.Dispatcher.Invoke(new Action<bool>(CloseWithResult), aResult);
        }

        private void CloseWithResult(bool aResult)
        {
            this.DialogResult = aResult;
            this.Close();
        }

        private void UpdateUISynchronize()
        {
            if (this.Dispatcher.CheckAccess())
            {
                Endisable();
            }
            else
            {
                this.Dispatcher.Invoke(new Action(Endisable));
            }

        }

        private void Endisable()
        {
            this.IsEnabled = !IsSending;
            this.borderProgress.Visibility = IsSending ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        private static byte[] GetKey(string password)
        {
            string pwd = null;

            if (Encoding.UTF8.GetByteCount(password) < 24)
            {
                pwd = password.PadRight(24, ' ');
            }
            else
            {
                pwd = password.Substring(0, 24);
            }
            return Encoding.UTF8.GetBytes(pwd);
        }

        #endregion Private Section

        #region Public Section

        /// <summary>
        /// Descrypto strings using 3DES (192 bits)
        /// </summary>
        public static string Decrypt(string data)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Mode = CipherMode.ECB;
            DES.Key = GetKey(rcSupport.UserAccess);

            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESEncrypt = DES.CreateDecryptor();
            Byte[] Buffer = Convert.FromBase64String(data.Replace(" ", "+"));

            return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// Get user machine information
        /// </summary>
        /// <returns>User machine information</returns>
        /// <remarks>Oliver Lee 21 Apr 05</remarks>
        public static string GetMachineInfo()
        {
            try
            {
                StringBuilder str = new StringBuilder();

                //Getting machine and user information
                str.AppendLine(string.Format(C_GetMachineInfo_Version, Environment.Version));
                str.AppendLine(string.Format(C_GetMachineInfo_OSVersion, Environment.OSVersion));

                return str.ToString();
            }
            catch (Exception)
            {
            }
            return string.Empty;
        }

        public static string GetAppInfo()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine(string.Format(C_Application_Name, System.Reflection.Assembly.GetEntryAssembly().GetName().Name));
                str.Append(string.Format(C_Application_Version, System.Reflection.Assembly.GetEntryAssembly().GetName().Version));
                return str.ToString();
            }
            catch (Exception)
            {
            }
            return string.Empty;
        }

        #endregion Public Section

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ErrorMessage);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Interop.ComponentDispatcher.IsThreadModal)
            {
                this.DialogResult = true;
            }
            this.Close();
        }        

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text) || (txtMail.Text.Contains("@") == false))
            {
                MessageBox.Show("Invalid E-Mail address. \r\nYour E-Mail is very important. \r\nWe will contact you as soon as possible when we have solution.");
                txtMail.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtMailContent.Text))
            {
                MessageBox.Show("Message connot be empty.");
                txtMailContent.Focus();
            }
            else
            {
                IsSending = true;
                EmailInfo info = new EmailInfo();
                info.From = rcSupport.UserProxyEmail;
                info.To = rcSupport.SupportEmail;
                info.Subject = txtSubject.Text;
                info.Body = string.Format("From User: {0}", txtMail.Text) + Environment.NewLine + txtMailContent.Text;
                info.ProxyName = rcSupport.UserProxyEmail;
                info.ProxyPwd = Decrypt(rcSupport.UserID);
                FSendingEmailThread = new Thread(new ParameterizedThreadStart(SendEmail));
                FSendingEmailThread.Start(info);
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text) == false)
            {
                try
                {
                    if (FSendingEmailThread != null && FSendingEmailThread.IsAlive)
                    {
                        FSendingEmailThread.Abort();
                        FSendingEmailThread.Join();
                    }
                    File.WriteAllText(SupportInfoPath, txtMail.Text);
                }
                catch (Exception)
                {                    
                }
            }
        }

        #endregion Events

        private class EmailInfo
        {
            public string To { get; set; }
            public string From { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public string ProxyName { get; set; }
            public string ProxyPwd { get; set; }
        }

    }
    
}
