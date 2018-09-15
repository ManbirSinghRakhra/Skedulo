using System;

namespace HelloWorld.Interfaces.InterfacesImpl
{
    public class MathFunctions : IMathFunctions
    {
        public bool DivisibleBy(double dividend, double divisor)
        {
            if (divisor.Equals(0))
            {
                throw new DivideByZeroException("Divisor cannot be Zero");
            }

            double remainder = 0;
            return remainder.Equals(dividend % divisor);
        }
    }
}
