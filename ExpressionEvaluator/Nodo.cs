﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    public class Nodo
    {
        public Argomento Arg1 { get; set; }
        public Operation Operation { get; set; }
        public Nodo Next { get; set; }
    }
}
