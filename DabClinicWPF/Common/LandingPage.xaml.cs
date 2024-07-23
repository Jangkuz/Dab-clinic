using DabClinicRepo.Models;
using DabClinicServies;
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
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        private AccountServices _accService;
        private ClinicTreatmentServices _clinicTreatmentService;
        public LandingPage()
        {
            InitializeComponent();
            _accService = new();
            _clinicTreatmentService = new();
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //Thu nho cua so 
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Dong app
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            login.Owner = this;
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SearchService_Click(object sender, RoutedEventArgs e)
        {
            Func<ClinicService, bool> filterByName = cliService => cliService.ServiceName!.ToLower().Equals(txt_ServiceName.Text.ToLower());
            var serviceList = _clinicTreatmentService.GetClinicServices(filterByName);
            SetServiceDataGrid(dataList: serviceList);
        }


        private void btn_SearchDentist_Click(object sender, RoutedEventArgs e)
        {
            Func<Account, bool> filterByName = account => account.Fullname!.ToLower().Equals(txt_DetistName.Text.ToLower());
            var denstistList = _accService.GetDentisList(filterByName);
            SetDentistDataGrid(dataList: denstistList);
        }

        private void dgv_DentisList_Loaded(object sender, RoutedEventArgs e)
        {
            SetDentistDataGrid(dataList: _accService.GetDentisList());
        }

        private void dgv_ServiceList_Loaded(object sender, RoutedEventArgs e)
        {
            SetServiceDataGrid(dataList: _clinicTreatmentService.GetClinicServices());

        }

        private void SetDentistDataGrid<T>(List<T> dataList)
        {
            dgv_DentisList.ItemsSource = null;
            dgv_DentisList.ItemsSource = dataList;
        }

        private void SetServiceDataGrid<T>(List<T> dataList)
        {
            dgv_ServiceList.ItemsSource = null;
            dgv_ServiceList.ItemsSource = dataList;
        }

    }
}
