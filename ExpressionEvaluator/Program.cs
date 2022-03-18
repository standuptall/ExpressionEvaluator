using System;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests();
            return;
            while (true)
            {

                Console.Write("Inserisci l'espressione: ");
                var stringa = Console.ReadLine();
                try
                {
                    var parser = new Parser(stringa);

                    Console.WriteLine("Risultato  :" + parser.Result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void Tests()
        {
            var errCount = 0;
            var parser = new Parser("2+3-6*9");
            if (parser.Result != -49)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("2-6*(5-2)");
            if (parser.Result != -16)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("2+5-8*(24/4*2)-5");
            if (parser.Result != -94)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("10/5-4+(2-4*2)");
            if (parser.Result != -8)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("64/8");
            if (parser.Result != 8)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            Console.WriteLine(errCount + " test non passati");
            Console.ReadLine();
        }
    }
}
