using HelloWorld.Interfaces;
using HelloWorld.Interfaces.InterfacesImpl;
using NUnit.Framework;

namespace HelloWorld.Tests
{
    [TestFixture]
    public class PrintFunctionsTests
    {
        public IPrintFunctions CreateDefaultPrintFunctions()
        {
            return new PrintFunctions();
        }


        [Test]
        public void PrintingHelloAndWorld_PassesParametersTrueAndFalse_ReturnHello()
        {
            IPrintFunctions iPrintFunctions = CreateDefaultPrintFunctions();
            string expected = "Hello";

            var actual = iPrintFunctions.PrintingHelloAndWorld(true, false);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void PrintingHelloAndWorld_PassesParametersFalseAndTrue_ReturnWorld()
        {
            IPrintFunctions iPrintFunctions = CreateDefaultPrintFunctions();
            string expected = "World";

            var actual = iPrintFunctions.PrintingHelloAndWorld(false, true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PrintingHelloAndWorld_PassesParametersFalseAndTrue_ReturnHelloWorld()
        {
            IPrintFunctions iPrintFunctions = CreateDefaultPrintFunctions();
            string expected = "HelloWorld";

            var actual = iPrintFunctions.PrintingHelloAndWorld(true, true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PrintingHelloAndWorld_PassesParametersFalseAndFalse_ReturnEmpty()
        {
            IPrintFunctions iPrintFunctions = CreateDefaultPrintFunctions();
            string expected = string.Empty;

            var actual = iPrintFunctions.PrintingHelloAndWorld(false, false);

            Assert.AreEqual(expected, actual);
        }
    }
}
