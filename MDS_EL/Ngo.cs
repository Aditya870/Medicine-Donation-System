using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Ngo
    {
         #region Attributes
        private int _ngoId;
        private string _ngoName;
        private string _ngoAddress;
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
        public string NgoAddress
        {
            get
            {
                return _ngoAddress;
            }
            set
            {
                _ngoAddress = value;
            }
        }
        #endregion
    }
}
