using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Invoice
    {
       #region Attributes
        private int _invoiceId;
        private string _donatorName;
        private string _ngoName;
        private string _medicineName;
        private int _quantity;
        private string _batchNumber;
        private DateTime _donatedDate;
        #endregion

 

        #region Properties
        public int InvoiceId
        {
            get
            {
                return _invoiceId;
            }
            set
            {
                _invoiceId = value;
            }
        } 
        public string DonatorName
        {
            get
            {
                return _donatorName;
            }
            set
            {
                _donatorName = value;
            }
        }
       public string NgoName
        {
            get
            {
                return _ngoName;
            }
            set
            {
                _ngoName = value;
            }
        }
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
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public DateTime DonatedDate
        {
            get
            {
                return _donatedDate;
            }
            set
            {
                _donatedDate = value;
            }
        }
        #endregion
    }
}
