using DabClinicRepo.Models;
using DabClinicRepo.Repositories;
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

namespace DabClinicWPF.ForDevelopmentTobeDeleted
{
    /// <summary>
    /// Interaction logic for TestingGround.xaml
    /// </summary>
    public partial class TestingGround : Window
    {
        private AccountServices _accService;
        private AccountRepository _accRepo; //For developing purpose
        public TestingGround()
        {
            InitializeComponent();
            _accService = new();
            _accRepo = AccountRepository.GetInstance(); //For developing purpose
        }

        

        private void dtgShowData_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }

        public void ReloadDataGrid()
        {
            dtgShowData.ItemsSource = null;
            dtgShowData.ItemsSource = _accRepo.GetAllAcccounts();
        }
    }
}
