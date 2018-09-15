namespace HelloWorld.Interfaces.InterfacesImpl
{
    public class PrintFunctions : IPrintFunctions
    {
        public string PrintingHelloAndWorld(bool printHello, bool printWorld)
        {
            string printing = string.Empty;
            if (printHello) printing += "Hello";
            if (printWorld) printing += "World";

            return printing;
        }
    }
}
