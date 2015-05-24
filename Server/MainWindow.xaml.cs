using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Core;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _log = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            _log.Add("Welcome! Server's logs will be shown here.");
            Logger.Log = _log;
            lbLog.ItemsSource = _log;
            ShowIP();
        }

        private void AccessSettings_Click(object sender, RoutedEventArgs e)
        {
            var wa = new wAccess();
            wa.ShowDialog();
        }

        private void ShowIP()
        {
            var addressList = ServerCore.GetAddressList();
            foreach (var address in addressList)
            {
                lbAddresses.Items.Add(address);
            }
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bStartServer.IsEnabled = false;
                if (ServerCore.IsStarted) //If started
                {
                    ServerCore.Stop();
                    StatusColor.Fill = Brushes.WhiteSmoke;
                    bStartServer.Content = "Start server";
                }
                else
                {
                    var port = Convert.ToInt32(tb_port.Text);
                    if (port < 0 || port > 65535)
                        throw new FormatException("Port is " + (port < 0 ? "negative" : "greater than 65535"));
                    bStartServer.Content = "Server starting...";
                    ServerCore.Start(port);
                    StatusColor.Fill = Brushes.LawnGreen;
                    bStartServer.Content = "Pause server";
                }
                bStartServer.IsEnabled = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Port format error: " + ex.Message);
                Logger.LogError("User input error. Port format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                StatusColor.Fill = Brushes.Red;
                Logger.LogError("Error: " + ex.Message);
            }
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
