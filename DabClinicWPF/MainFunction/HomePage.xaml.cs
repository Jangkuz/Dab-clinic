﻿using Dab_clinic_WPF.Common;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        private AccountServices _accService;
        private ClinicTreatmentServices _clinicTreatmentService;
        public HomePage()
        {
            InitializeComponent();
            _accService = new AccountServices();
            _clinicTreatmentService = new ClinicTreatmentServices();
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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SearchDentist_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBookAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewResult_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewNoti_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewDentistList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewChedule_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewPatients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewMyInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

