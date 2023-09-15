using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Shipping
    {
       #region Attribues
        private int _shippingID;
        private int _donatorID;
        private int _ngoID;
        private string _deliveryAddress;
        private string _pickupAddress;
        private string _batchNumber;
        #endregion

        #region Properties
        public int ShippingId
        {
            get
            {
                return _shippingID;
            }
            set
            {
                _shippingID = value;
            }
        }
        public int DonatorId
        {
            get
            {
                return _donatorID;
            }
            set
            {
                _donatorID = value;
            }
        }
        public int NgoId
        {
            get
            {
                return _ngoID;
            }
            set
            {
                _ngoID = value;
            }
        }
        public string DeliveryAddress
        {
            get
            {
                return _deliveryAddress;
            }
            set
            {
                _deliveryAddress = value;
            }
        }
        public string PickupAddress
        {
            get
            {
                return _pickupAddress;            
            }
            set
            {
                _pickupAddress = value;
            }
        }
        public string BatchNumber { get; set; }
        #endregion
    }
}
