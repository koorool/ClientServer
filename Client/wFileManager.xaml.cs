using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Core;

namespace Client
{
    /// <summary>
    /// Interaction logic for wFileManager.xaml
    /// </summary>
    public partial class wFileManager : Window
    {
        private ObservableCollection<string> Log = new ObservableCollection<string>(); 
        public wFileManager()
        {
            InitializeComponent();
            Logger.Log = Log;
            lbLog.ItemsSource = Log;
            Logger.LogEvent("Connected to ");
        }

    }
}
