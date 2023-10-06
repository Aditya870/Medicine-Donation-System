using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
   public class UserType
    {
        #region Attributes
        private int _userTypeId;
        private string _userTypeName;
        private DateTime _dateCreated;
        private DateTime _dateModified;
        private string _createdBy;
        private string _modifiedBy;
        #endregion

        #region Properties
        
        public int UserTypeId
        {
            get
            {
                return _userTypeId;
            }
            set
            {
                _userTypeId = value;
            }
        }
        public string UserTypeName
        {
            get
            {
                return _userTypeName;
            }
            set
            {
                _userTypeName = value;
            }
        }
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = value;
            }
        }
        public DateTime DateModified
        {
            get
            {
                return _dateModified;
            }
            set
            {
                _dateModified = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return _createdBy;
            }
            set
            {
                _createdBy = value;
            }
        }
        public string ModifiedBy
        {
            get
            {
                return _modifiedBy;
            }
            set
            {
                _modifiedBy = value;
            }
        }
        #endregion
    }
}
