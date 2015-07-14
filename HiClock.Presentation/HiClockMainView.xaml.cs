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

namespace HiClock.Presentation
{
    /// <summary>
    /// Interaction logic for HiClockMainView.xaml
    /// </summary>
    [Export(typeof(IHiClockMainView)), PartCreationPolicy(CreationPolicy.NonShared)]
    internal partial class HiClockMainView : UserControl, IHiClockMainView
    {
        [ImportingConstructor]
        public HiClockMainView()
        {
            InitializeComponent();
        }

    }
}
