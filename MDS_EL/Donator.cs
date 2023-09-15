using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Donator
    {
        #region Attributes   
        private int _donatorId;
        private string _donatorName;
        private string _donatorAddress;
         
        #endregion 

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
        public string DonatorAddress
        {
            get
            {
                return _donatorAddress;
            }
            set
            {
                _donatorAddress = value;
            }
        }
        
        #endregion
    }
}
