using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MDS_EL;
using MDS_Exception;

namespace MDS_DAL
{
    public class DataAccessLayer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;
        
        
        //Default Constructor
        public DataAccessLayer()
        {
            
            con = new SqlConnection();
            con.ConnectionString = @"server=(LocalDB)\MSSQLLocalDB;Integrated Security = true; Database = MedicineDonationDb";
        }


        #region Invoice 

       /// <summary>
        /// Generates the invoice
        /// </summary>
        /// <param name="shippingId">Shipping Id</param>
        /// <returns>Returns true if Invoice is Generated</returns>
        public int GenerateInvoice(int shippingId)
        {
            int invoiceId = -1;
            try
            {
                con.Open();
                SqlParameter p1;


                p1 = new SqlParameter("@ShippingId", shippingId);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_GenerateInvoice";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                cmd.Parameters.AddWithValue("@InvoiceId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                invoiceId = Convert.ToInt32(cmd.Parameters["@InvoiceId"].Value.ToString());

            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return invoiceId;
        }



        
        /// <summary>
        /// Display the Invoice details
        /// </summary>
        /// <returns>Returns true for all the invoice details</returns>
        public List<Invoice> ViewInvoiceDetails()
        {
            List<Invoice> invoiceList = new List<Invoice>();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "usp_ViewInvoiceDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();

                //Converting DataTable Into List

                if (dt.Rows.Count > 0)
                {
                    Invoice i = null;

                    foreach (DataRow dRow in dt.Rows)
                    {
                     i = new Invoice();
                        i.InvoiceId = Convert.ToInt32(dRow[0].ToString());
                        i.DonatorName = dRow[1].ToString();
                        i.NgoName = dRow[2].ToString();
                        i.MedicineName = dRow[3].ToString();
                        i.Quantity = Convert.ToInt32(dRow[4].ToString());
                        i.BatchNumber = dRow[5].ToString();
                        i.DonatedDate = Convert.ToDateTime(dRow[6].ToString());
                        invoiceList.Add(i);
                    }
                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return invoiceList;
        }

        #endregion




        #region Shipping
        
        /// <summary>
        /// Shows all shipping Details
        /// </summary>
        /// <returns>Returns all shipping Details</returns>
        public List<Shipping> Select_Shipping()
        {
            List<Shipping> ShippingList = new List<Shipping>();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "usp_Select_Shipping";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(sdr);


                con.Close();

                //Converting DataTable Into List

                if (dt.Rows.Count > 0)
                {
                    Shipping s1 = null;

                    foreach (DataRow dRow in dt.Rows)
                    {
                        s1 = new Shipping();
                        s1.ShippingId = Int32.Parse(dRow[0].ToString());
                        s1.DonatorId = Int32.Parse(dRow[1].ToString());
                        s1.PickupAddress = dRow[2].ToString();
                        s1.DeliveryAddress = dRow[3].ToString();
                        s1.NgoId = Int32.Parse(dRow[4].ToString());
                        s1.BatchNumber = dRow[5].ToString();
                        ShippingList.Add(s1);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return ShippingList;
        }




        /// <summary>
        /// ViewShippingById displays Shipping Details By Shipping Id
        /// </summary>
        /// <param name="shippingId">Shipping Id</param>
        /// <returns>Returns true if Shipping Details can be displayed by Id</returns>
        public Shipping ViewShippingById(int shippingId)
        {
            Shipping ship = new Shipping();
            try
            {
                con.Open();
                SqlParameter p;
                p = new SqlParameter("@shippingId ", shippingId);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_viewby_ShippingId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr != null)
                {

                    ship.ShippingId = Convert.ToInt32(sdr[0].ToString());
                    ship.DonatorId = Convert.ToInt32(sdr[1].ToString());
                    ship.PickupAddress = sdr[2].ToString();
                    ship.DeliveryAddress = sdr[3].ToString();
                    ship.NgoId = Convert.ToInt32(sdr[4].ToString());
                    ship.BatchNumber = sdr[5].ToString();

                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return ship;
        }

        #endregion




        #region Medicine
        
        /// <summary>
        /// AddMedicine adds new medicine to medicine table
        /// </summary>
        /// <param name="medicineName">Medicine Name</param>
        /// <param name="medicineStatus">Medicine Status</param>
        /// <param name="medicineQty">Medicine Quantity</param>
        /// <param name="medicineManufacturer">Medicine Manufacturer</param>
        /// <param name="batchNumber">Medicine Batch Number</param>
        /// <param name="expiryDate">Medicine Expiry Date</param>
        /// <returns>Returns true if a medicine is added</returns>
        public bool AddMedicine(string medicineName, string medicineStatus, int medicineQty, string medicineManufacturer, string batchNumber, DateTime expiryDate)
        {
            try
            {
                con.Open();

                SqlParameter p1, p2, p3, p4, p5, p6;

                p1 = new SqlParameter("@MedicineName", medicineName);
                p2 = new SqlParameter("@MedicineStatus", medicineStatus);
                p3 = new SqlParameter("@MedicineQty", medicineQty);
                p4 = new SqlParameter("@MedicineManufacturer", medicineManufacturer);
                p5 = new SqlParameter("@BatchNumber", batchNumber);
                p6 = new SqlParameter("@ExpiryDate", expiryDate);


                cmd = new SqlCommand();
                cmd.CommandText = "usp_InsertMedicine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return true;
        }

        


        /// <summary>
        /// DeleteMedicineByBatchNumber is used to Delete Medicine in Medicine Table
        /// </summary>
        /// <param name="BatchNumber">Batch Number</param>
        /// <returns>Returns true if medicine is deleted</returns>
        public bool DeleteMedicineByBatchNumber(string batchNumber)
        {
            try
            {
                con.Open();

                SqlParameter p;
                p = new SqlParameter("@BatchNumber", batchNumber);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_DeleteMedicine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return true;
        }



        
        /// <summary>
        /// ViewAllMedicine is used to display all the medicines of Medicine table
        /// </summary>
        /// <returns>Returns list of all medicines</returns>
        public List<Medicine> ViewAllMedicine()
        {
            List<Medicine> medicineList = new List<Medicine>();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "usp_DisplayMedicine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();

                //Converting DataTable Into List

                if (dt.Rows.Count > 0)
                {
                    Medicine m = null;

                    foreach (DataRow dRow in dt.Rows)
                    {
                        m = new Medicine();

                        m.MedicineName = dRow[0].ToString();
                        m.MedicineStatus = dRow[1].ToString();
                        m.MedicineQty = Convert.ToInt32(dRow[2].ToString());
                        m.MedicineManufacturer = dRow[3].ToString();
                        m.BatchNumber = dRow[4].ToString();
                        m.ExpiryDate = Convert.ToDateTime(dRow[5].ToString());

                        medicineList.Add(m);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return medicineList;
        }




        /// <summary>
        /// ViewMedicineByBatchNumber displays a medicine by batch number
        /// </summary>
        /// <param name="batchNumber">Batch Number</param>
        /// <returns>Returns true if the medicine is available by its batch number</returns>
        public Medicine ViewMedicineByBatchNumber(string batchNumber)
        {
            Medicine m = new Medicine();
            try
            {
                con.Open();
                SqlParameter p;
                p = new SqlParameter("@BatchNumber ", batchNumber);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_SearchMedicine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr != null)
                {
                    m.MedicineName = sdr[0].ToString();
                    m.MedicineStatus = sdr[1].ToString();
                    m.MedicineQty = Convert.ToInt32(sdr[2].ToString());
                    m.MedicineManufacturer = sdr[3].ToString();
                    m.BatchNumber = sdr[4].ToString();
                    m.ExpiryDate = Convert.ToDateTime(sdr[5].ToString());

                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return m;
        }

        #endregion




        #region NGO 

        /// <summary>
        /// AddNgo adds new ngo in the table
        /// </summary>
        /// <param name="NgoId">Ngo Id</param>
        /// <param name="NgoName">Ngo Name</param>
        /// <param name="NgoAddress">Name Address</param>
        /// <returns>Returns true if ngo is Added</returns>
        public bool AddNgo(int ngoId, string ngoName, string ngoAddress)
        {
            try
            {
                con.Open();

                SqlParameter p1, p2, p3;

                p1 = new SqlParameter("@NgoId", ngoId);
                p2 = new SqlParameter("@NgoName", ngoAddress);
                p3 = new SqlParameter("@NgoAddress", ngoAddress);


                cmd = new SqlCommand();
                cmd.CommandText = "usp_Insert_Ngo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return true;
        }
       



        /// <summary>
        /// UpdateNgo updates Ngo in the table
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <param name="ngoName">Ngo Name</param>
        /// <param name="ngoAddress">Ngo Address</param>
        /// <returns>Returns true if ngo is updated</returns>
        public bool UpdateNgo(int ngoId, string ngoName, string ngoAddress)
        {
            try
            {
                con.Open();

                SqlParameter p1, p2, p3;

                p1 = new SqlParameter("@NgoId", ngoId);
                p2 = new SqlParameter("@NgoName", ngoName);
                p3 = new SqlParameter("@NgoAddress", ngoAddress);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_Update_Ngo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return true;

        }

        


        /// <summary>
        /// DeleteNgoById deletes the ngo from the list
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <returns>Returns true if ngo is deleted</returns>
        public bool DeleteNgoById(int ngoId)
        {
            try
            {
                con.Open();

                SqlParameter p;
                p = new SqlParameter("@NgoId", ngoId);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_Delete_Ngo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return true;
        }

        


        /// <summary>
        /// ViewAllNgo displays all the Ngo present in the table
        /// </summary>
        /// <returns>Returns list of Ngo</returns>
        public List<Ngo> ViewAllNgo()
        {
            List<Ngo> ngoList = new List<Ngo>();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "usp_Select_Ngo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();

                //Converting DataTable Into List

                if (dt.Rows.Count > 0)
                {
                    Ngo n = null;

                    foreach (DataRow dRow in dt.Rows)
                    {
                        n = new Ngo();

                        n.NgoId = Convert.ToInt32(dRow[0].ToString());
                        n.NgoName = dRow[1].ToString();
                        n.NgoAddress = dRow[2].ToString();

                        ngoList.Add(n);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return ngoList;
        }

        


        /// <summary>
        /// SearchNgoById Searches the Ngo table using NgoId
        /// </summary>
        /// <param name="NgoId">Ngo Id</param>
        /// <returns>Returns the searched Ngo</returns>
        public Ngo SearchNgoById(int NgoId)
        {
            Ngo ngoObj = new Ngo();
            try
            {
                con.Open();
                SqlParameter p;
                p = new SqlParameter("@NgoId", NgoId);



                cmd = new SqlCommand();
                cmd.CommandText = "usp_SearchNgoById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                cmd.Parameters.Add(p);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr != null)
                {

                    ngoObj.NgoId = Convert.ToInt32(sdr[0].ToString());

                    ngoObj.NgoName = sdr[1].ToString();
                    ngoObj.NgoAddress = sdr[2].ToString();

                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return ngoObj;
        }

        #endregion




        #region Donator

        /// <summary>
        /// Deletes Record of Donator based on ID
        /// </summary>
        /// <param name="donatorId">Donator Id</param>
        /// <returns>Returns true if record gets deleted</returns>
        public bool DeleteDonator(int donatorId)
        {
            try
            {

                con.Open();

                SqlParameter d;
                d = new SqlParameter("@DonatorId", donatorId);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_DeleteDonator";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(d);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }




        /// <summary>
        /// Returns a list of Donators
        /// </summary>
        /// <returns>Returns true after displaying the donator list</returns>
        public List<Donator> ViewAllDonator()
        {
            List<Donator> donatorList = new List<Donator>();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "usp_DisplayDonator";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();

                //Converting DataTable Into List

                if (dt.Rows.Count > 0)
                {
                    Donator d = null;

                    foreach (DataRow dRow in dt.Rows)
                    {
                        d = new Donator();
                        d.DonatorId = Convert.ToInt32(dRow[0].ToString());

                        d.DonatorName = dRow[1].ToString();
                        d.DonatorAddress = dRow[2].ToString();

                        donatorList.Add(d);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return donatorList;

        }
        


        
        /// <summary>
        /// Displays donatro by its Id
        /// </summary>
        /// <param name="donatorId">Donator Id</param>
        /// <returns>Returns true if donator is present as per the donator id</returns>
        public Donator ViewDonatorById(int donatorId)
        {
            Donator donator = new Donator();
            try
            {
                con.Open();
                SqlParameter p;
                p = new SqlParameter("@DonatorId ", donatorId);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_SearchDonator";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr != null)
                {

                    donator.DonatorId = Convert.ToInt32(sdr[0].ToString());

                    donator.DonatorName = sdr[1].ToString();
                    donator.DonatorAddress = sdr[2].ToString();

                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return donator;
        }

        #endregion




        #region Claim 
        
        /// <summary>
        /// Gets all the claim details
        /// </summary>
        /// <returns>Returns true for displaying all the claim details</returns>
        public List<Claim>  GetClaimDetail()
        {
            
            List<Claim> claimList = new List<Claim>();

        
            try{
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "usp_DisplayAllClaimDetail";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

        

                    sdr = cmd.ExecuteReader();

        

                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    con.Close();

        

                    //Converting DataTable Into List

        

                    if(dt.Rows.Count > 0)
                    {
                        Claim c1 = null;

        

                        foreach (DataRow dRow in dt.Rows)
                        {
                            c1 = new Claim();
                            c1.NgoId = Int32.Parse(dRow[0].ToString());
                            c1.BatchNumber = dRow[1].ToString();
                            c1.ClaimDate = Convert.ToDateTime(dRow[2].ToString());
                        
                            claimList.Add(c1);
                        }
                    }
                }
            catch (SqlException ex)
                    {
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                    return claimList;
        }




        /// <summary>
        /// Get Claim Details By NgoId
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <returns>Returns List of Claim Details Searched based on NgoId</returns>
        public Claim  GetClaimDetail(int ngoId)
        {

            Claim claim = new Claim();

            try
            {
                con.Open();
                SqlParameter p1;
                p1 = new SqlParameter("@ngoid", ngoId);
                cmd = new SqlCommand();
                cmd.CommandText = "usp_DisplayClaimDetailByNgoId ";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);

                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr != null)
                {
                    
                    claim.NgoId = Convert.ToInt32(sdr[0].ToString());

                    claim.BatchNumber = sdr[1].ToString();
                    claim.ClaimDate = Convert.ToDateTime(sdr[2].ToString());

                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return claim;
        }


        

        /// <summary>
        /// This method adds a claim 
        /// </summary>
        /// <param name="claim">Claim object</param>
        /// <returns>Returns a Claim object</returns>
        public bool AddClaim(Claim claim)
        {
                try
                {
                    con.Open();

                    SqlParameter p1, p2;

                    p1 = new SqlParameter("@NgoId", claim.NgoId);
                    p2 = new SqlParameter("@BatchNumber", claim.BatchNumber);
                

                    cmd = new SqlCommand();
                    cmd.CommandText = "usp_InsertClaimDetail";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            con.Close();
            return true;
        }

        #endregion





        #region Complaints 
        
        /// <summary>
        /// Adds a complaint Record
        /// </summary>
        /// <param name="complainsSuggestions">Object of class ComplainsSuggestions</param>
        /// <returns>Returns true and adds an Object of class ComplainsSuggestions</returns>
        public bool AddComplaintRecord(ComplainsSuggestions complainsSuggestions)
        {
            try
            {
                con.Open();

                SqlParameter p1, p2, p3, p4;

                p1 = new SqlParameter("@NgoId", complainsSuggestions.NgoId);
                p2 = new SqlParameter("@NgoName", complainsSuggestions.NgoName);
                p3 = new SqlParameter("@Complains", complainsSuggestions.Complains);
                p4 = new SqlParameter("@Suggestions", complainsSuggestions.Suggestions);

                cmd = new SqlCommand();
                cmd.CommandText = "usp_InsertComplaintRecord";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        #endregion




        #region Login 

        /// <summary>
        ///  Login Authentication 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="password">Pasword</param>
        /// <returns>Returns Usertypeid </returns>
        /// newly updated
        public int UserLogin(int userId, string passWord)
        {
            int usertypeid = -1;
            try
            {
                con.Open();
                SqlParameter p1, p2;
                p1 = new SqlParameter("@userId", userId);
                p2 = new SqlParameter("@Password", passWord);

                cmd = new SqlCommand();
                cmd.CommandText = "select userTypeId from Users where userId=@userId and Password=@Password";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    usertypeid = Int32.Parse(sdr[0].ToString());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return usertypeid;
        }




        /// <summary>
        ///  Verify User Exist Or Not
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <returns>Returns True if User exists </returns>
        ///new updated
        public bool VerifyUserExist(int userid)
        {
            bool isexist = false;


            try
            {

                con.Open();
                SqlParameter p1;
                cmd = new SqlCommand();

                p1 = new SqlParameter("@userid", userid);



                cmd.CommandText = "select userId from Users where userId=@userid ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);

                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows) // hasrows  = to check rows exist or not in result of query
                {
                    isexist = true;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return isexist;
        }




        /// <summary>
        ///  Insert User Detail
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <param name="userTypeId">User Type Id</param>
        /// <param name="Address">Address</param>
        /// <returns>Returns True if inserted successfully </returns>
        /// newly updated
        public bool InsertUser(int userid, string userName, string passWord, int userTypeId, string Address)
        {
            bool isinserted = false;


            try
            {

                con.Open();
                SqlParameter p1, p2, p3, p4, p5;
                cmd = new SqlCommand();




                p1 = new SqlParameter("@userId", userid);
                p2 = new SqlParameter("@userName", userName);
                p3 = new SqlParameter("@password", passWord);
                p4 = new SqlParameter("@userTypeId", userTypeId);
                p5 = new SqlParameter("@useraddress", Address);


                cmd.CommandText = "usp_InsertUserData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.ExecuteNonQuery();
                isinserted = true;


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            con.Close();
            return isinserted;
        }

        #endregion




        #region Donated Detail 
        
        /// <summary>
        /// Add Donated Detail
        /// </summary>
        /// <param name="DonatorId">Donator Id</param>
        /// <param name="BatchNumber">Batch Number</param>
        /// <returns>Returns True if Donated detail added successfully</returns>
        public bool AddDonatedDetail(int donatorId,string batchNumber)
        {
            try
                    {
                        con.Open();

                        SqlParameter p1, p2;

                        p1 = new SqlParameter("@DonatorId", donatorId);
                        p2 = new SqlParameter("@BatchNumber", batchNumber);
                    

                        cmd = new SqlCommand();
                        cmd.CommandText = "usp_InsertintoDonated";  
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Add(p1);
                        cmd.Parameters.Add(p2);
                    
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                    con.Close();
                    return true;
        }
       
        #endregion


    }
}



