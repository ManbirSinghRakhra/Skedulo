using HelloWorld.Interfaces;
using HelloWorld.Interfaces.InterfacesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        private static IMathFunctions iMathFunctions;
        private static IPrintFunctions iPrintFunctions;
        
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            iMathFunctions = new MathFunctions();
            iPrintFunctions = new PrintFunctions();
            PrintHelloAndWorld();
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static void PrintHelloAndWorld()
        {
            for(int i = 1; i <= 100; i++)
            {
                if(iMathFunctions.DivisibleBy(i, 4) || iMathFunctions.DivisibleBy(i, 5))
                    Console.WriteLine(iPrintFunctions.PrintingHelloAndWorld(iMathFunctions.DivisibleBy(i, 4), iMathFunctions.DivisibleBy(i, 5)));
            }
        }
    }
}
