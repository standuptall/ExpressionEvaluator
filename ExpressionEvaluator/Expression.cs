using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    public class Expression
    {
        public Expression(string toParse, List<Variabile> variabiles)
        {
            this.Variables = variabiles;
            var index = 0;
            string substring = toParse;
            Nodo oldNodo = null;
            var count = 0;
            //verifico se ci sono variabili
            while (substring.Contains("@"))
            {
                var index1 = substring.IndexOf("@");
                index = index1;
                string varname = "";
                while (!Operation.isOperation(substring[index].ToString()))
                {
                    varname += substring[index].ToString();
                    index++;
                    if (index == substring.Length)
                        break ;
                }
                var onlyname = varname.Substring(1, varname.Length - 1);
                if (Variables == null || !Variables.Any(c => c.Name.ToLower().Equals(onlyname)))
                    throw new Exception("Variabile \""+onlyname+"\" non trovata");
                substring = substring.Replace(varname, 
                    Variables
                    .Where(c=>c.Name.ToLower().Equals(onlyname))
                    .FirstOrDefault()?
                    .Value
                    .ToString(CultureInfo.InvariantCulture));

            }
            //trovo prima il numero
            do
            {
                double? arg1 = GetNumber(substring, out index);
                substring = substring.Substring(index, substring.Length - index); 
                if (substring.Length == 0)
                {
                    if (oldNodo != null) 
                        oldNodo.Next = new Nodo
                        {
                            Arg1 = new Argomento(arg1),
                            Operation = null
                        };
                    else
                        PrimoNodo = new Nodo
                        {
                            Arg1 = new Argomento(arg1),
                            Operation = null
                        }; ;
                    break;
                }
                Operation operation = Operation.GetOperation(substring, out index);
                substring = substring.Substring(index, substring.Length - index);
                Nodo legame = new Nodo
                {
                    Arg1 = new Argomento(arg1),
                    Operation = operation
                };
                if (oldNodo != null)
                    oldNodo.Next = legame;
                if (count == 0)
                    PrimoNodo = legame;
                oldNodo = legame;
                count++;
            } while (true);
            ;
        }
        public Nodo PrimoNodo { get; }
        public List<Variabile> Variables { get; internal set; }

        private double? GetNumber(string toParse, out int position)
        {
            var substr = toParse;
            string extracted = "";
            int index = 0;
            bool minus = false;
            if (substr[index] == '-')
            {
                minus = true;
                index = 1;
            }
            while (char.IsNumber(substr[index]) || substr[index] == '.')
            {
                extracted += substr[index];
                index++;
                if (index == substr.Length)
                    break;
            }
            position = index;
            if (string.IsNullOrEmpty(extracted))
                return null;
            return double.Parse(extracted,CultureInfo.InvariantCulture) * (minus ? -1 : 1);
        }
        public double Evaluate()
        {
            double result = 0;
            Nodo nodo = PrimoNodo;

            if (nodo.Next == null)
                return nodo.Arg1.NumberVal ?? 0;
            //====PRIORITA 1=====
            for(int priority = 0; priority < 4; priority++ )
            {
                nodo = PrimoNodo;
                while (true)
                {
                    if (nodo.Operation?.GetPriority() == priority)
                    {
                        var nextarg = nodo.Next.Arg1;
                        result = nodo.Operation.GetResult(nodo.Arg1.NumberVal, nextarg.NumberVal.Value);
                        nodo.Arg1 = new Argomento(result);
                        if (nodo.Next.Next == null)
                        {
                            nodo.Next = null;
                            nodo.Operation = null;
                            break;
                        }
                        Nodo sosti = nodo.Next.Next;
                        nodo.Operation = nodo.Next.Operation;
                        nodo.Next = sosti;
                    }
                    else
                        nodo = nodo.Next;
                    if (nodo == null)
                        break;
                }
            }
            return result;
        }

        
    }
}
