using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmLogin.Exceptions
{
    class ServerExceptions : Exception
    {
        public ServerExceptions():base("Server error - KLIJENTSAK STRANA")
        {
        }

        public ServerExceptions(string message) : base(message)
        {
        }
    }
}
