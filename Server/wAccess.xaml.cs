using System;
using System.Collections.Generic;
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

namespace Server
{
    /// <summary>
    /// Interaction logic for wAccess.xaml
    /// </summary>
    public partial class wAccess : Window
    {
        public wAccess()
        {
            InitializeComponent();
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            wConfigureAccess wCA = new wConfigureAccess();
            wCA.ShowDialog();
        }
    }
}
