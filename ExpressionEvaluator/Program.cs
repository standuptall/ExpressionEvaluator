using System;
using System.Collections.Generic;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tests();
            //return;
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
            parser = new Parser("2^5-6");
            if (parser.Result != 26)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("6-2radq(64)");
            if (parser.Result != -10)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("+5");
            if (parser.Result != 5)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("5");
            if (parser.Result != 5)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("-5.5*2-0.1");
            if (parser.Result != -11.1)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("2*4/5*(-1+2)");
            if (parser.Result != 1.6)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("1947/4+43/4");
            if (parser.Result != 497.5)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            parser = new Parser("@variabile+4",new List<Variabile>() { new Variabile("variabile",98) });
            if (parser.Result != 102)
            {
                Console.WriteLine("Test " + parser.RawExpression + " failed");
                errCount++;
            }
            Console.WriteLine(errCount + " test non passati");
            Console.ReadLine();
        }
    }
}
