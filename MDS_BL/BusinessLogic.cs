using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDS_DAL;
using MDS_Exception;
using MDS_EL;

namespace MDS_BL
{
    public class BusinessLogic
    {
        DataAccessLayer dal = null;

        //Default Constructor
        public BusinessLogic()
        {
            dal = new DataAccessLayer();
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
            if (ValidateShippingId(shippingId))
            {
                invoiceId = dal.GenerateInvoice(shippingId);
            }
            return invoiceId;
        }
        



        /// <summary>
        /// Displays all the invoice Details
        /// </summary>
        /// <returns>Returns List of Invoice</returns>
        public List<Invoice> ViewInvoiceDetails()
        {
            return dal.ViewInvoiceDetails();
        }

        #endregion




        #region Complaints

        /// <summary>
        /// Validates Complaint
        /// </summary>
        /// <param name="complainsSuggestions">Object of class ComplainsSuggestions</param>
        /// <returns>Returns true if complaint is validated</returns>
        public bool ValidateComplaint(ComplainsSuggestions complainsSuggestions)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (String.IsNullOrEmpty(complainsSuggestions.NgoName))
                {
                    isValid = false;
                    builder.Append("NGO Name Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(complainsSuggestions.Complains))
                {
                    isValid = false;
                    builder.Append("Complaint Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(complainsSuggestions.Suggestions))
                {
                    isValid = false;
                    builder.Append("Suggestion Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }

                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }


        

        /// <summary>
        /// Adds a complaint record
        /// </summary>
        /// <param name="complainsSuggestions">Object of class ComplainsSuggestions</param>
        /// <returns>Returns an Object of class ComplainsSuggestions</returns>
        public bool AddComplaintRecord(ComplainsSuggestions complainsSuggestions)
        {
            bool isAdded = false;
            if (ValidateComplaint(complainsSuggestions))
            {
                isAdded = dal.AddComplaintRecord(complainsSuggestions);
            }
            return isAdded;
        }

        #endregion




        #region Medicine

        /// <summary>
        /// ValidateMedicines validates the medicine
        /// </summary>
        /// <param name="medicineName">Medicine Medicine Name</param>
        /// <param name="medicineStatus">Medicine Status</param>
        /// <param name="medicineQty">Medicine Quantity</param>
        /// <param name="medicineManufacturer">Medicine Manufacturer</param>
        /// <param name="batchNumber">Medicine Batch Number</param>
        /// <param name="expiryDate">Medicine Expiry Date</param>
        /// <returns>Returns true if it is validated</returns>
        public bool ValidateMedicine(string medicineName, string medicineStatus, int medicineQty, string medicineManufacturer, string batchNumber, DateTime expiryDate)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (String.IsNullOrEmpty(medicineName))
                {
                    isValid = false;
                    builder.Append("MedicineName Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(medicineStatus))
                {
                    isValid = false;
                    builder.Append("MedicineStatus Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (medicineQty < 0)
                {
                    isValid = false;
                    builder.Append("MedicineQty cannot be less than 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(medicineManufacturer))
                {
                    isValid = false;
                    builder.Append("MedicineManufacturer Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(batchNumber))
                {
                    isValid = false;
                    builder.Append("BatchNumber Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                var todaysDate = DateTime.Today;
                int result = DateTime.Compare(expiryDate, todaysDate);
                if (result < 0)
                {
                    isValid = false;
                    builder.Append("Medicine Expiry Date Cannot be less than today's date");
                    builder.Append(Environment.NewLine);

                }

                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }




        /// <summary>
        /// ValidateBatchNumber validates the BatchNumber
        /// </summary>
        /// <param name="batchNumber">Batch Number</param>
        /// <returns>Returns true if BatchNumber is validated</returns>
        public bool ValidateBatchNumber(string batchNumber)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (String.IsNullOrEmpty(batchNumber))
                {
                    isValid = false;
                    builder.Append("BatchNumber Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }
        



        /// <summary>
        /// AddMedicine adds new medicine
        /// </summary>
        /// <param name="medicineName">Medicine Name</param>
        /// <param name="medicineStatus">Medicine Status</param>
        /// <param name="medicineQty">Medicine Quantity</param>
        /// <param name="medicineManufacturer">Medicine Manufacturer</param>
        /// <param name="batchNumber">Medicine Batch Number</param>
        /// <param name="expiryDate">Medicine Expiry Date</param>
        /// <returns>Returns true if new medicine is added</returns>
        public bool AddMedicine(string medicineName, string medicineStatus, int medicineQty, string medicineManufacturer, string batchNumber, DateTime expiryDate)
        {
            bool isAdded = false;
            if (ValidateMedicine(medicineName, medicineStatus, medicineQty, medicineManufacturer, batchNumber, expiryDate))
            {
                isAdded = dal.AddMedicine(medicineName, medicineStatus, medicineQty, medicineManufacturer, batchNumber, expiryDate);
            }
            return isAdded;
        }
       
       
        

        /// <summary>
        /// DeleteMedicine deletes the medicine by BatchNumber
        /// </summary>
        /// <param name="batchNumber">Batch Number</param>
        /// <returns>Returns true if medicine is deleted</returns>
        public bool DeleteMedicineByBatchNumber(string batchNumber)
        {
            bool isDeleted = false;
            if (ValidateBatchNumber(batchNumber))
            {
                isDeleted = dal.DeleteMedicineByBatchNumber(batchNumber);
            }
            return isDeleted;
        }

        


        /// <summary>
        /// ViewAllMedicine displays all the medicines
        /// </summary>
        /// <returns>Returns list of medicines</returns>
        public List<Medicine> ViewAllMedicine()
        {
            return dal.ViewAllMedicine();
        }




        /// <summary>
        /// ViewMedicineByBatchNumber displays a medicine by batch number
        /// </summary>
        /// <param name="batchNumber">Batch Number</param>
        /// <returns>Returns true if the medicine is available by its batch number</returns>
        public Medicine ViewMedicineByBatchNumber(string batchNumber)
        {
            return dal.ViewMedicineByBatchNumber(batchNumber);
        }

        #endregion




        #region NGO 

        /// <summary>
        /// Validation of Ngo
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <param name="ngoName">Ngo Name</param>
        /// <param name="ngoAddress">Ngo Address</param>
        /// <returns>Returns true if validation is done</returns>
        public bool ValidateNgo(int ngoId, string ngoName, string ngoAddress)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {

                if (ngoId <= 0)
                {
                    isValid = false;
                    builder.Append("NgoId cannot be 0 or less than 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(ngoName))
                {
                    isValid = false;
                    builder.Append("Ngo Name Cannot be Empty");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(ngoAddress))
                {
                    isValid = false;
                    builder.Append("Ngo Address Cannot be Empty");
                    builder.Append(Environment.NewLine);
                }

                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }
        



        /// <summary>
        /// Validate NgoId
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <returns>Returns true if NgoId is validated</returns>
        public bool ValidateNgoId(int ngoId)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (ngoId <= 0)
                {
                    isValid = false;
                    builder.Append("Ngo ID cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }
        
       

        
        /// <summary>
        /// UpdateNgo updates the Ngo
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <param name="ngoName">Ngo Name</param>
        /// <param name="ngoAddress">Ngo Address</param>
        /// <returns>Returns true if it is updated</returns>
        public bool UpdateNgo(int ngoId, string ngoName, string ngoAddress)
        {
            bool isAdded = false;
            if (ValidateNgo(ngoId, ngoName, ngoAddress))
            {
                isAdded = dal.UpdateNgo(ngoId, ngoName, ngoAddress);
            }
            return isAdded;
        }



        
        /// <summary>
        /// Delete a Ngo
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <returns>Returns true if Ngo is deleted</returns>
        public bool DeleteNgoById(int ngoId)
        {

            bool isDeleted = false;
            if (ValidateNgoId(ngoId))
            {
                isDeleted = dal.DeleteNgoById(ngoId);
            }
            return isDeleted;
        }
        
        


        /// <summary>
        /// ViewAllNgo displays the list of all ngo
        /// </summary>
        /// <returns>Returns list of all Ngo</returns>
        public List<Ngo> ViewAllNgo()
        {
            return dal.ViewAllNgo();
        }



        /// <summary>
        /// SearchNgoById seaches the ngo by the ngo Id
        /// </summary>
        /// <param name="ngoId">Ngo Id</param>
        /// <returns>Returns true if Ngo Id is available</returns>
        public Ngo SearchNgoById(int ngoId)
        {
            return dal.SearchNgoById(ngoId);
        }

        #endregion




        #region Claim
        
        /// <summary>
        /// Adds a Claim
        /// </summary>
        /// <param name="claim">Claim object</param>
        /// <returns>Returns a Claim object</returns>

        public bool AddClaim(Claim claim)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (claim.NgoId <= 0)
                {
                    isValid = false;
                    builder.Append("NGO ID cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(claim.BatchNumber))
                {
                    isValid = false;
                    builder.Append("Batch Number Cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (dal.AddClaim(claim));


        }




        /// <summary>
        /// Displays all the Claim Details
        /// </summary>
        /// <returns>Returns List of Claims</returns>
        public List<Claim> GetClaimDetail()
        {
            return dal.GetClaimDetail();
        }




        /// <summary>
        /// Displays all the Claim Details By Id
        /// </summary>
        /// <param name="ngoId">NgoId</param>
        /// <returns>Returns List of Claims</returns>
        public Claim GetClaimDetail(int ngoId)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (ngoId <= 0)
                {
                    isValid = false;
                    builder.Append("NGO ID cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return (dal.GetClaimDetail(ngoId));

        }
       
        #endregion




        #region Donator
        
        /// <summary>
        /// Validate Donator Id
        /// </summary>
        /// <param name="donatorId">Donator Id</param>
        /// <returns>Returns true if Id is Valid</returns>
        public bool ValidateDonatorId(int donatorId)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (donatorId <= 0)
                {
                    isValid = false;
                    builder.Append("DonatorId cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }




        /// <summary>
        /// Delete Record by ID
        /// </summary>
        /// <param name="donatorId">Donator Id</param>
        /// <returns>Returns true when record gets deleted</returns>
        public bool DeleteDonator(int donatorId)
        {
            bool isDeleted = false;
            if (ValidateDonatorId(donatorId))
            {
                isDeleted = dal.DeleteDonator(donatorId);
            }
            return isDeleted;
        }




        /// <summary>
        /// ViewAllDonator displays all donator
        /// </summary>
        /// <returns>Returns true after displayig the donator</returns>
        public List<Donator> ViewAllDonator()
        {
            return dal.ViewAllDonator();
        }




        /// <summary>
        /// Displays donator by Id
        /// </summary>
        /// <param name="donatorId">Donator Id</param>
        /// <returns>Returns true if donator is present with Donator id</returns>
        public Donator ViewDonatorById(int donatorId)
        {
            return dal.ViewDonatorById(donatorId);
        }

        #endregion




        #region Shipping
        
        /// <summary>
        /// Validating Shipping id 
        /// </summary>
        /// <param name="shippingId">Shipping Id</param>
        /// <returns>Returns true if Shipping id is valid</returns>
        public bool ValidateShippingId(int shippingId)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (shippingId <= 0)
                {
                    isValid = false;
                    builder.Append("ShippingId cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;
        }


        

        /// <summary>
        /// Displays all details of Shipping
        /// </summary>
        /// <returns>Returns details of shipping</returns>
        public List<Shipping> Select_Shipping()
        {
            return dal.Select_Shipping();
        }
       




        /// <summary>
        /// ViewShippingById displays Shipping Details By Shipping Id
        /// </summary>
        /// <param name="shippingId">Shipping Id</param>
        /// <returns>Returns true if Shipping Details can be displayed by Id</returns>
        public Shipping ViewShippingById(int shippingId)
        {
            return dal.ViewShippingById(shippingId);
        }

        #endregion




        #region Login 

        /// <summary>
        ///  Login Authentication 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="password">Password</param>
        /// <returns>Returns Usertypeid </returns>
        public int UserLogin(int userId, string passWord)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (userId <= 0)
                {
                    isValid = false;
                    builder.Append("UserId cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(passWord))
                {
                    isValid = false;
                    builder.Append("Password Cannot be Emplty or null");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (isValid)
            {
                return dal.UserLogin(userId, passWord);
            }
            else
            {
                return -1;
            }
        }





        /// <summary>
        ///  Validate User Detail
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <param name="userTypeId">User Type Id</param>
        /// <param name="Address">Address</param>
        /// <returns>Returns True if User detail is valid </returns>
        ///  /// newly updated
        public bool ValidateUserDetail(int userid, string userName, string passWord, int userTypeId, string Address)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (userid <= 0)
                {
                    isValid = false;
                    builder.Append("UserId cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(userName))
                {
                    isValid = false;
                    builder.Append("UserName cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(passWord))
                {
                    isValid = false;
                    builder.Append("password cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (userTypeId <= 0)
                {
                    isValid = false;
                    builder.Append("UserTypeId cannot be 0");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(Address))
                {
                    isValid = false;
                    builder.Append("Address cannot be Empty or null");
                    builder.Append(Environment.NewLine);
                }

                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;

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
        ///newly updated
        public bool InsertUser(int userid, string userName, string passWord, int userTypeId, string Address)
        {
            bool isinserted = false;
            if (ValidateUserDetail(userid, userName, passWord, userTypeId, Address))
            {
                isinserted = dal.InsertUser(userid, userName, passWord, userTypeId, Address);
            }
            return isinserted;
        }





        /// <summary>
        ///  Validate User Id 
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <returns>Returns True if Userid is valid </returns>
        public bool ValidateUserId(int userid)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (userid <= 0)
                {
                    isValid = false;
                    builder.Append("UserId cannot be 0");
                    builder.Append(Environment.NewLine);
                }


                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isValid;

        }




        /// <summary>
        ///  Verify User Exist Or Not
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <returns>Returns True if User exists </returns>
        /// newly updated
        public bool VerifyUserExist(int userid)
        {
            bool isexist = false;
            if (ValidateUserId(userid))
            {
                isexist = dal.VerifyUserExist(userid);
            }
            return isexist;
        }

        #endregion




        #region Donated Detail

        /// <summary>
        /// Add Donated Detail
        /// </summary>
        /// <param name="DonatorId">Donator Id</param>
        /// <param name="BatchNumber">Batch Number</param>
        /// <returns>Returns True if Donated detail added successfully</returns>

        public bool AddDonatedDetail(int DonatorId, string BatchNumber)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();
            try
            {
                if (DonatorId <= 0)
                {
                    isValid = false;
                    builder.Append("Donator ID cannot be 0 or negative");
                    builder.Append(Environment.NewLine);
                }
                if (String.IsNullOrEmpty(BatchNumber))
                {
                    isValid = false;
                    builder.Append("Batch Number Cannot be Emplty or null");
                    builder.Append(Environment.NewLine);
                }
                if (!isValid)
                {
                    throw new UserDefinedException(builder.ToString());
                }
            }
            catch (Exception)
            {
                throw;
                
            }
            if (isValid)
            {
                return dal.AddDonatedDetail(DonatorId, BatchNumber);
            }
            else
            {
                return false;
            }

        }

        #endregion

       

    }
}
