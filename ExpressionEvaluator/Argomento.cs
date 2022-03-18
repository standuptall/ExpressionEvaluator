using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    public class Argomento
    {
        public Argomento(string argument)
        {
            var esito = double.TryParse(argument, out double res);
            if (esito)
                this.IsNumber = true;
            this.Arg = argument;
        }
        public Argomento(double argument)
        {
            this.IsNumber = true;
            this.Arg = argument.ToString();
        }
        public Nodo Prec { get; set; }
        public bool IsNumber { get; }
        public string Arg { get; }
        public double NumberVal
        {
            get
            {
                if (!IsNumber)
                    return 0;
                return double.Parse(this.Arg);
            }
        }
        public override string ToString()
        {
            return Arg;
        }
    }
}
