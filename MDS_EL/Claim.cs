using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Claim
    {
        #region Attributes
        private int _ngoId;
        private string _batchNumber;
        private DateTime _claimDate;
        #endregion

        #region Properties
        public int NgoId
        {
            get
            {
                return _ngoId;
            }
            set
            {
                _ngoId = value;
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
        public DateTime ClaimDate
        {
            get
            {
                return _claimDate;
            }
            set
            {
                _claimDate = value;
            }
        }
        #endregion


    }
}
