using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Donated
    {
        #region Attributes
        private int _donatorId;
        private string _batchNumber;
        private DateTime _donatedDate;
        #endregion Attributes

        #region Properties
        public int DonatorId
        {
            get
            {
                return _donatorId;
            }
            set
            {
                _donatorId = value;
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
        #endregion
    }
}
