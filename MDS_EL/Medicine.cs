using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Medicine
    {
        #region Attributes      
        //private int _medicineId;
        private string _medicineName;
        private string _medicineStatus;
        private int _medicineQty;
        private string _medicineManufacturer;
        private string _batchNumber;//also refffered as medicine ID
       // private DateTime _manufactureDate;
        private DateTime _expiryDate;
        #endregion

        #region Properties
        /*public int MedicineId
        {
            get
            {
                return _medicineId;
            }
            set
            {
                _medicineId = value;
            }
        }*/

        public string MedicineName
        {
            get
            {
                return _medicineName;
            }
            set
            {
                _medicineName = value;
            }
        }
        public string MedicineStatus
        {
            get
            {
                return _medicineStatus;
            }
            set
            {
                _medicineStatus = value;
            }
        }
        public int MedicineQty
        {
            get
            {
                return _medicineQty;
            }
            set
            {
                _medicineQty = value;
            }
        }
        public string MedicineManufacturer
        {
            get
            {
                return _medicineManufacturer;
            }
            set
            {
                _medicineManufacturer = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return _batchNumber;
            }
            set
            {
                _batchNumber = value;
            }
        }
      /*  public DateTime ManufactureDate
        {
            get
            {
                return _manufactureDate;
            }
            set
            {
                _manufactureDate = value;
            }
        } */
        public DateTime ExpiryDate

        {
            get
            {
                return _expiryDate;
            }
            set
            {
                _expiryDate = value;
            }


        }
        #endregion
    }
}
