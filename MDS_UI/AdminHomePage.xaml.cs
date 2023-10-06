using System;
using System.Collections.Generic;
using System.IO;
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
using MDS_BL;
using MDS_EL;
using Microsoft.Win32;


namespace MDS_UI
{
    /// <summary>
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        BusinessLogic bl = null;
        Donator d = null;
        Users u = null;

        public AdminHomePage()
        {
            InitializeComponent();
        }
        #region Tabs Loading
        private void Ngo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                List<Ngo> ngoList = bl.ViewAllNgo();
                grdNgo.ItemsSource = ngoList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Donator_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                List<Donator> DonatorList = bl.ViewAllDonator();
                grdDonator.ItemsSource = DonatorList;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Medicine_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                List<Medicine> medicineDetails = bl.ViewAllMedicine();
                grdMedicine.ItemsSource = medicineDetails;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Invoice_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                List<Invoice> invoiceDetails = bl.ViewInvoiceDetails();
                grdAllInvoiceDetails.ItemsSource = invoiceDetails;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden; // to hide current Window
            MessageBox.Show("Logout", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            objMainWindow.Show();

        }
        #endregion

        #region NGO
        // NGO


        private void ButtonViewNgo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();

                int ngId = Convert.ToInt32(ngoId.Text);
                Ngo ng = bl.SearchNgoById(ngId);
                Ngo[] arrNgo = new Ngo[] { ng };
                grdNgo.ItemsSource = arrNgo;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonAddNgo_Click(object sender, RoutedEventArgs e)
        {
            Register objregisterWindow = new Register();
            this.Visibility = Visibility.Hidden; // to hide current Window
            objregisterWindow.Show();
        }
        private void ButtonUpdateNgo_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                bl = new BusinessLogic();
                int ngId = Convert.ToInt32(ngoId.Text);
                string ngName = ngoName.Text;
                string ngAddress = ngoAddress.Text;
                bool flag = bl.UpdateNgo(ngId, ngName, ngAddress);
                if (flag == true)
                    MessageBox.Show("Ngo Updated Successfully..!");
                else
                    MessageBox.Show("Ngo Updatation Failed..!");
                Ngo_Loaded(sender, e);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonDeleteNgo_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                bl = new BusinessLogic();
                int ngId = Convert.ToInt32(ngoId.Text);

                bool flag = bl.DeleteNgoById(ngId);
                if (flag == true)
                    MessageBox.Show("Ngo Delete Successfull..!");
                else
                    MessageBox.Show("Ngo Delete Unsuccessfull..!");
                Ngo_Loaded(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        #endregion

        #region Donator
        // Donator

        private void ButtonViewDonator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();

                int donateId = Convert.ToInt32(donatorId.Text);
                Donator don = bl.ViewDonatorById(donateId);
                Donator[] arrDon = new Donator[] { don };
                grdDonator.ItemsSource = arrDon;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ButtonAddDonator_Click(object sender, RoutedEventArgs e)
        {

            Register objregisterWindow = new Register();
            this.Visibility = Visibility.Hidden; // to hide current Window
            objregisterWindow.Show();

        }
        private void ButtonUpdateDonator_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDeleteDonator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                int donateId = Convert.ToInt32(donatorId.Text);
                bool isDeleted;

                isDeleted = bl.DeleteDonator(donateId);
                if (isDeleted)
                {
                    MessageBox.Show("Deleted Successfully..!");
                }
                else
                {
                    MessageBox.Show("Delete Unsuccessfully..!");
                }
                Donator_Loaded(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Medicine
        // Medicine

        private void ButtonViewMedicine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();

                string batchNo = batchNumber.Text;
                Medicine med = bl.ViewMedicineByBatchNumber(batchNo);
                Medicine[] arrMed = new Medicine[] { med };
                grdMedicine.ItemsSource = arrMed;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            DonatorWindow objDonatorWindow = new DonatorWindow();
            this.Visibility = Visibility.Hidden; // to hide current Window
            objDonatorWindow.Show();

        }
        private void ButtonUpdateMedicine_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void ButtonDeleteMedicine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                string batchNo = batchNumber.Text;
                bool isDeleted = false;

                isDeleted = bl.DeleteMedicineByBatchNumber(batchNo);
                if (isDeleted)
                {
                    MessageBox.Show("Deleted Successfully..!");
                }
                else
                {
                    MessageBox.Show("Delete Unsuccessfully..!");
                }
                Medicine_Loaded(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        #endregion

        #region Shipping Tab
        // Shipping

        private void ButtonViewShipping_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();

                int shipId = Convert.ToInt32(shippingId.Text);
                Shipping ship = bl.ViewShippingById(shipId);
                Shipping[] arrship = new Shipping[] { ship };
                grdShipping.ItemsSource = arrship;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonAddShipping_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonUpdateShipping_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDeleteShipping_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonLogout3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden; // to hide current Window
            MessageBox.Show("Logout Successful", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            objMainWindow.Show();
        }
        #endregion

        #region Invoice Tab
        // invoice


        private void ButtonGenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                int shippingId = Convert.ToInt32(txt_shippingId.Text);
                int InvoiceId = bl.GenerateInvoice(shippingId);
                Shipping shipping = new Shipping();
                shipping = bl.ViewShippingById(shippingId);
                Shipping[] s = new Shipping[] { shipping };
                grdInvoiceDetails.ItemsSource = s;

                string bNo = shipping.BatchNumber;
                Medicine medicine = new Medicine();
                medicine = bl.ViewMedicineByBatchNumber(bNo);
                Medicine[] m = new Medicine[] { medicine };
                
                grdShippingDetails.ItemsSource = m;

                List<Invoice> invoiceDetails = bl.ViewInvoiceDetails();
                grdAllInvoiceDetails.ItemsSource = invoiceDetails;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void Shipping_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BusinessLogic bl = new BusinessLogic();
                List<Shipping> shippinglist = new List<Shipping>();
                shippinglist = bl.Select_Shipping();
                if (shippinglist != null) { grdShipping.ItemsSource = shippinglist; }
                else { MessageBox.Show("No shipping Record Found", "Error", MessageBoxButton.OK, MessageBoxImage.Information); }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TabItemReload_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ngo_Loaded(sender,e);
            Donator_Loaded(sender, e);
            Medicine_Loaded(sender, e);
            Shipping_Loaded(sender, e);
        }

       
    }
}
