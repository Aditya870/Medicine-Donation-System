using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS_Exception
{
    public class UserDefinedException : ApplicationException
    {
        public UserDefinedException(): base()
        {

        }
        public UserDefinedException(string message): base(message)
        {

        }
    }
}
