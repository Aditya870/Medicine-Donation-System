using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class Users
    {
        #region Attributes
        private int _userId;
        private string _userName;
        private string _password;
        private string _userTypeId;
        private DateTime _dateCreated;
        private DateTime _dateModified;
        private string _createdBy;
        private string _modifiedBy;
        #endregion

        #region Properties
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string UserTypeId
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
