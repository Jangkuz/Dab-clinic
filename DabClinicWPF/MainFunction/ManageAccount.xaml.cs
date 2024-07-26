using DabClinicRepo.Enums;
using DabClinicRepo.HelperClass;
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

namespace DabClinicWPF.MainFunction
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : Window
    {

        private AccountServices _accService;
        private Account? _selectAccount = null;

        public Role ManageRole { get; set; }
        public ManageAccount()
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
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Func<Account, bool> filterByName = acc => acc.Fullname!.ToLower().Contains(txt_FullName.Text.ToLower());
            Func<Account, bool> filterByPhoneNumber = acc => acc.Phone!.ToLower().Contains(txt_PhoneNumber.Text.ToLower());

            SetAccountDgv(QueryAccount(filterByName, filterByPhoneNumber));
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ReloadAccountDgv();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ReloadAccountDgv();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectAccount == null)
            {
                MessageBox.Show("Please select an account to Delete", "Select an account", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var msgBoxRes = MessageBox.Show($"Are you sure you want to DELETE {_selectAccount.Fullname}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msgBoxRes == MessageBoxResult.No)
            {
                _selectAccount = null;
                return;
            }

            bool deleteSuccess = _accService.DeleteAccount(_selectAccount);
            if (deleteSuccess)
            {
                MessageBox.Show("Delete successful!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Delete unsuccessful!", "Result", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            _selectAccount = null;
            ReloadAccountDgv();

        }

        private void dgv_AccountList_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadAccountDgv();

        }

        private void dgv_AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgv_AccountList.SelectedItem != null)
            {
                //System.Type type = dtgAirConditioner.SelectedItem.GetType();
                //int selectedAirConId = (int)type.GetProperty("AirConditionerId")!.GetValue(dtgAirConditioner.SelectedItem, null)!; 

                int selectedAccountId = Helper.GetDtgSelectedItemAttr<int>(dgv_AccountList.SelectedItem, "Id");

                _selectAccount = _accService.GetAccountById(selectedAccountId);

            }
        }

        //get selection change


        private List<Account> QueryAccount(params Func<Account, bool>[] conditions)
        {
            Func<Account, bool> filterRole = acc => acc.Role == ManageRole;
            List<Func<Account, bool>> tempCondition = conditions.ToList();
            tempCondition.Add(filterRole);

            List<Account> accounts = _accService.GetAccountByCondition(tempCondition.ToArray());
            return accounts;
        }

        private void ReloadAccountDgv()
        {
            SetAccountDgv(dataList: QueryAccount());
        }

        private void SetAccountDgv<T>(List<T> dataList)
        {
            dgv_AccountList.ItemsSource = null;
            dgv_AccountList.ItemsSource = dataList;
        }
    }
}
