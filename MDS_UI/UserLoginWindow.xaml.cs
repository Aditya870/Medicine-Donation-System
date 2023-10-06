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
using System.Data.SqlClient;
using System.Configuration;
using MDS_BL;
using MDS_EL;
using MDS_DAL;
using MDS_Exception;

namespace MDS_UI
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
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            // to open new window
            int userTypeId;
            BusinessLogic bl = new BusinessLogic();
            userTypeId = bl.UserLogin(Convert.ToInt32(txt_userId.Text), txt_password.Password);
            if (userTypeId == 1)  //if login user is admin
            {
                AdminHomePage objAdminHomePage = new AdminHomePage();
                this.Visibility = Visibility.Hidden; // to hide current Window
                MessageBox.Show("Login Admin", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
                objAdminHomePage.Show();
                //  MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (userTypeId == 2)  // if login user is NGO
            {
                NgoWindow objNgoWindow = new NgoWindow();
                this.Visibility = Visibility.Hidden; // to hide current Window

                objNgoWindow.Show();
                MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (userTypeId == 3)  //if login user is donator
            {
                DonatorWindow objDonatorWindow = new DonatorWindow();
                this.Visibility = Visibility.Hidden; // to hide current Window
                objDonatorWindow.Show();
                MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("UserId or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            Register objregisterWindow = new Register();
            this.Visibility = Visibility.Hidden; // to hide current Window
            objregisterWindow.Show();
        }
    }
}
