using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmLogin.Exceptions
{
    public class SystemOperationException : Exception
    {
        public SystemOperationException():base("Server couldnt process request.")
        {
        }

        public SystemOperationException(string message) : base(message)
        {
        }
    }
}
