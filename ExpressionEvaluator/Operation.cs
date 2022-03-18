using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    public class Operation
    {
        private static string[] allowed = new string[] { "+", "-", "*", "/" };
        private Operation(string symbol) 
        {

            this._symbol = symbol;
        }
        private string _symbol { get; set; }
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }
        public double GetResult(double arg1, double arg2)
        {
            switch (Symbol)
            {
                case "+": return arg1 + arg2; 
                case "-": return arg1 - arg2; 
                case "/": return arg1 / arg2; 
                case "*": return arg1 * arg2; 
                default:throw new Exception("Simbolo sconosciuto: " + Symbol);
            }
        }

        public static Operation GetOperation(string substring, out int index)
        {
            var find = allowed.Where(c => substring.StartsWith(c)).FirstOrDefault();
            if (find == null)
                throw new Exception("Not a valid operator: " + substring);
            index = find.Length;
            return new Operation(find);
        }

        internal int GetPriority()
        {
            switch (Symbol)
            {
                case "+": return 2;
                case "-": return 2;
                case "/": return 1;
                case "*": return 1;
                default: throw new Exception("Simbolo sconosciuto: " + Symbol);
            }
        }
    }
    
}
