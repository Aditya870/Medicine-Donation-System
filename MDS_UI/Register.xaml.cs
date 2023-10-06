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
using System.Data.SqlClient;
using System.Configuration;
using MDS_BL;
using MDS_EL;
using MDS_DAL;
using MDS_Exception;

namespace MDS_UI
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
      
        
            private void ButtonRegisterUser_Click(object sender, RoutedEventArgs e)
            {
                int userid;
                string username;
                string Password;
                int usertypeid;
                string Address;
                bool isValid;
                userid = Convert.ToInt32(userId.Text);
                username = userName.Text;
                Password = password.Password;
                if (userTypeId.Text == "NGO")
                    usertypeid = 2;
                else
                    usertypeid = 3;
                Address = address.Text;
                if (Password == repassword.Password)
                {
                    BusinessLogic bl = new BusinessLogic();
                    if (bl.VerifyUserExist(userid))
                    {
                        MessageBox.Show("User Already Exists. Please enter another userId..!");
                    }

                    else
                    {
                        isValid = bl.InsertUser(userid, username, Password, usertypeid, Address);
                        if (isValid)
                        { MessageBox.Show("User Inserted..!"); }
                        else
                        { MessageBox.Show("User Not Inserted..!"); }
                    }
                }
                else
                {
                    MessageBox.Show("Re-entered Password does not match with previous. Please try again..!");
                }
                MainWindow objMainWindow = new MainWindow(); // mainwindow is login window
                this.Visibility = Visibility.Hidden; // to hide current Window
                objMainWindow.Show();
            }
        
        
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow(); // mainwindow is login window
            this.Visibility = Visibility.Hidden; // to hide current Window
            objMainWindow.Show();
        }
    }
}
