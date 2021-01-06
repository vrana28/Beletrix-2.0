using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Response
    {
        public string Error { get; set; }
        public bool IsSuccessful { get; set; }
        public Object Result { get; set; }

    }
}
