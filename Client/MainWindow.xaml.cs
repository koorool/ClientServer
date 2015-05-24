using System;
using System.Net;
using System.Windows;
using Core;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int port;
            try
            {
                IPAddress.Parse(tbIPAddress.Text);
            }
            catch
            {
                lMessage.Content = "IP Address is not correct!";
                return;
            }
            try
            {
                port = Int32.Parse(tbPort.Text);
                if (port < 0 || port > 65535)
                {
                    throw new Exception();
                }
            }
            catch
            {
                lMessage.Content = "Port is incorrect";
                return;
            }
            if (ClientCore.Connect(tbIPAddress.Text, port))
            {
                new wFileManager().Show();
                Close();
            }
            else
            {
                lMessage.Content = "Cannot connect";
            }
        }
    }
}
