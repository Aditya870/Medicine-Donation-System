using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Admin
    {
        #region Attributes
        private int _adminId;
        private string _adminName;
        private string _adminAddress;
        #endregion

        #region Properties
        public string AdminAddress
        {
            get
            {
                return _adminAddress;
            }
            set
            {
                _adminAddress = value;
            }
        }
        public int AdminId
        {
            get
            {
                return _adminId;
            }
            set
            {
                _adminId = value;
            }
        }
        public string AdminName
        {
            get
            {
                return _adminName;
            }
            set
            {
                _adminName = value;
            }
        }
        #endregion
    }
}
