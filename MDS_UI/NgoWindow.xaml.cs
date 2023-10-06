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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MDS_BL;
using MDS_EL;


namespace MDS_UI
{
    /// <summary>
    /// Interaction logic for NgoWindow.xaml
    /// </summary>
    public partial class NgoWindow : Window
    {
        BusinessLogic bl = null;
        public NgoWindow()
        {
            InitializeComponent();

        }


        private void NgoClaim_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                List<Medicine> medicineDetails = bl.ViewAllMedicine();
                grdMedicine.ItemsSource = medicineDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ComplaintsSuggestion_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSubmitComplaint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComplainsSuggestions complainsSuggestions = new ComplainsSuggestions();
                complainsSuggestions.NgoId = Convert.ToInt32(ngoId.Text);
                complainsSuggestions.NgoName = ngoName.Text;
                complainsSuggestions.Complains = Complaint.Text;
                complainsSuggestions.Suggestions = Suggestions.Text;
                bl = new BusinessLogic();

                bool flag = bl.AddComplaintRecord(complainsSuggestions);
                if (flag == true)
                    MessageBox.Show("Complaint Registered..!");
                else
                    MessageBox.Show("Complaint Not Registered..!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden; // to hide current Window
            MessageBox.Show("Logout", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            objMainWindow.Show();
        }



        private void ButtonClaim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Claim claim = new Claim();
                claim.NgoId = Convert.ToInt32(ngoID.Text);
                claim.BatchNumber = batchNumber.Text;
                bl = new BusinessLogic();
                bool flag = bl.AddClaim(claim);
                if (flag == true)
                    MessageBox.Show("Medince Claim Successful..!");
                else
                    MessageBox.Show("Medince Claim Unsuccessful..!");
                ClaimStaus_Loaded(sender, e);
                NgoClaim_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClaimStaus_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = new BusinessLogic();
                List<Claim> claimDetails = bl.GetClaimDetail();
                grdClaimStatus.ItemsSource = claimDetails;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonReload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClaimStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ngId = Convert.ToInt32(txt_ngoId.Text);
                bl = new BusinessLogic();
                bl.GetClaimDetail(ngId);
                ClaimStaus_Loaded(sender, e);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }

        }


    }
}
