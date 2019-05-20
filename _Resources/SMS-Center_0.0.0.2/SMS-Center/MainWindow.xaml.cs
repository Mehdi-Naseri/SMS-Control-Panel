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
            try
            {
                ServiceReference1.SendSoapClient SendSoapClient1 = new ServiceReference1.SendSoapClient();
                textboxCredit.Text = SendSoapClient1.GetCredit("homa", "20402041").ToString();
            }
            catch
            {
            }
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
           // try
          //  {
                long[] recId = new long[1];
                byte[] status = new byte[1];

                ServiceReference1.ArrayOfString stringArrayTo1 = new ServiceReference1.ArrayOfString();
                stringArrayTo1.Add("09177393373");

                ServiceReference1.ArrayOfLong ArrayOfLong = new ServiceReference1.ArrayOfLong();

            //    string[] stringArrayTo = new string[1];
            //    stringArrayTo[0] = "09177393373";

                   ServiceReference1.SendSoapClient SendSoapClient1 = new ServiceReference1.SendSoapClient();

                // SendSoapClient1.se
                   int intResult = SendSoapClient1.SendSms("web-raya", "Pseez.ir", stringArrayTo1, "300073806", "تست", false, "", ref ArrayOfLong, ref status);
                switch (intResult)
                {
                    case 0:
                        MessageBox.Show("نام کاربری یا رمز عبور صحیح نمی باشد");
                        break;
                    case 1:
                        MessageBox.Show("ارسال با موفقیت انجام شد");
                        break;
                    case 2:
                        MessageBox.Show("اعتبار کافی نیست");
                        break;
                    case 3:
                        MessageBox.Show("محدودیت در ارسال روزانه");
                        break;
                    case 4:
                        MessageBox.Show("محدودیت در حجم ارسال");
                        break;
                    case 5:
                        MessageBox.Show("شماره فرستنده معتبر نیست");
                        break;
                    default:
                        MessageBox.Show(string.Format("Unknown Error."+intResult));
                        break;
                }
        /*    }
            catch
            {

            }*/
        }
        /*
               public bool sendSms(string mobile, bool typeMessage)
               {
                   net.epayamak.Send objepayamak = new net.epayamak.Send();
                   long[] recId = new long[1];
                   byte[] status = new byte[1];
                   int r = 0;
                   string[] to = new string[1];

                   //string msg = "کد رهگیری : " + "\r\n" + generatePk_Code() + "\n\r" + DateTime.Now.Date.Date.ToString().Substring(0, 10)+"\n\r"+DateTime.Now.TimeOfDay.ToString().Substring(0, 7) ;
                   string fullName = txtName.Text + " " + txtFamily.Text;
                   string msg = staticClass2.kanon + "\r\n" + "نام:" + fullName + "\r\n" + "گروه علاقه مندی:" + ddlFavorites.SelectedItem.Text + "\r\n" + staticClass2.codeRahgiri + "\r\n" + generatePk_Code() + " " + "\r\n" + staticClass2.pseez + "\r\n" + staticClass2.pseez_ir;
                   to[0] = mobile;

                   r = objepayamak.SendSms(staticClass2.username, staticClass2.password, to, staticClass2.numberSpec, msg, typeMessage, "", ref  recId, ref status);
                   if (r == 1 && status[0] == 0)
                       return true;
                   else
                       return false;
               }
       */
    }
}
