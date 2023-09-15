using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_EL
{
    public class ComplainsSuggestions
    {
      
    
        #region Attributes
        private int _complainId;
        private int _ngoId;
        private string _ngoName;
        private string _complains;
        private string _suggestions;
        #endregion

 

        #region Properties
        public int ComplainId
        {
            get
            {
                return _complainId;
            }
            set
            {
                _complainId = value;
            }
        }
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
        public string Complains
        {
            get
            {
                return _complains;
            }
            set
            {
                _complains = value;
            }
        }
        public string Suggestions
        {
            get
            {
                return _suggestions;
            }
            set
            {
                _suggestions = value;
            }
        }
        #endregion
    


    }

}
