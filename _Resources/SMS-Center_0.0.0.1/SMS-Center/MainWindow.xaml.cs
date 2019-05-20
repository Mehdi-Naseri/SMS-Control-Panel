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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SMS_Center
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

        private void buttonCredit_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.SendSoapClient SendSoapClient1 = new ServiceReference1.SendSoapClient();
            textboxCredit.Text = SendSoapClient1.GetCredit("homa","20402041").ToString();
        }
    }
}
