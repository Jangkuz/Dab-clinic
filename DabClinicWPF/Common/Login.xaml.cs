using DabClinicRepo.HelperClass;
using DabClinicRepo.Models;
using DabClinicServies;
using DabClinicWPF.MainFunction;
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

namespace Dab_clinic_WPF.Common
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private AccountServices _accService;
        public Login()
        {
            InitializeComponent();
            _accService = new();
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //============================================================
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            Account? loginAccount = null;
            List<String> errorList = new();
            bool canLogin = _accService.Login(txtEmail.Text, txtPass.ToString(), out loginAccount, out errorList);
            if (!canLogin)
            {
                //iterate error list to show error dialog box

                if (errorList.Contains(ErrorMessages.UsernamePwdErr))
                {
                    MessageBox.Show(ErrorMessages.Messages[ErrorMessages.UsernamePwdErr], "Login fail", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                MessageBox.Show(ErrorMessages.Messages[ErrorMessages.UnknowError], "Unknow error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            //pass in loginAccount to HomePage

            this.Close();
            this.Owner.Close();
            HomePage homePage = new HomePage();
            homePage.Owner = this;
            homePage.Show();
            //Mo man hinh chuc nang


        }
    }

}
