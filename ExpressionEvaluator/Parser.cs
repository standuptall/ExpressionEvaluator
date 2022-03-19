using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    public class Parser
    {
        List<Variabile> variabiles = null;
        public Parser(string toParse,List<Variabile> variabiles)
        {
            this.variabiles = variabiles;
            Constructor(toParse);
        }
        public Parser(string toParse)
        {
            Constructor(toParse);
        }
        private void Constructor(string toParse)
        {
            RawExpression = toParse;
            var substring = toParse;
            double result = 0;
            //trovo l'ultima parentesi aperta e la prima chiusa
            while (substring.Contains("("))
            {
                var ind1 = substring.LastIndexOf("(");
                var ind2 = substring.IndexOf(")", ind1);
                if (ind2 < 0)
                    throw new Exception("Parentesi chiusa mancante :" + substring);
                var rawexp = substring.Substring(ind1 + 1, ind2 - ind1 - 1);
                var exp = new Expression(rawexp,variabiles);
                result = exp.Evaluate();
                var repla = result.ToString().Replace(",", ".");
                int substraction = 0;
                if (result < 0) //attenzione carattere
                {
                    while (!char.IsNumber(substring[ind1 - substraction]))
                        substraction++;
                    substraction--;
                }
                substring = substring.Substring(0, ind1 - substraction) + repla + substring.Substring(ind2 + 1);
            }
            var expf = new Expression(substring,variabiles);
            this.Result = expf.Evaluate();
        }
        public string RawExpression { get; internal set; }
        public double Result { get; internal set; }
    }
}
