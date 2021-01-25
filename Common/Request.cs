﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Request
    {
        public Object RequestObject { get; set; }
        public Operation Operation { get; set; }
        public Object RequestObject2 { get; set; }
        public string Text { get; set; }
    }
}
