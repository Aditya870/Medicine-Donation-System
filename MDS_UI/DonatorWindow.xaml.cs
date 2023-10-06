using MDS_BL;
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
using Calendar = System.Windows.Controls.Calendar;
using CalendarMode = System.Windows.Controls.CalendarMode;
using CalendarModeChangedEventArgs = System.Windows.Controls.CalendarModeChangedEventArgs;
using DatePicker = System.Windows.Controls.DatePicker;
using MDS_EL;

namespace MDS_UI
{
    /// <summary>
    /// Interaction logic for DonatorWindow.xaml
    /// </summary>
    public partial class DonatorWindow : Window
    {
        BusinessLogic bl = null;
        Donator donator = null;
        Medicine medicine = null;
        public DonatorWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden; // to hide current Window
            MessageBox.Show("Logout", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            objMainWindow.Show();
        }
        private void ButtonDonation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                donator = new Donator();
                medicine = new Medicine();
                int DonatorId = Convert.ToInt32(userName.Text);
                string MedicineName = medicineName.Text;
                string MedicineManufacturer = medicineManufacturer.Text;
                int MedicineQty = Convert.ToInt32(medicineQty.Text);
                string BatchNumber = batchNumber.Text;
                DateTime expireDate = Convert.ToDateTime(expiryDate.Text);
                bool flag = bl.AddMedicine(MedicineName, "Available", MedicineQty, MedicineManufacturer, BatchNumber, expireDate);
                if (flag)
                {
                    bl.AddDonatedDetail(DonatorId, BatchNumber);
                    MessageBox.Show("Medicine Donated Successfully..!");
                }
                else
                    MessageBox.Show("Medicine Could not be donated..!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loaded_DonationDetails(object sender, RoutedEventArgs e)
        {

        }
    }
}
