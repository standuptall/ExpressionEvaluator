using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    public class Variabile
    {
        public Variabile(string name,double value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
