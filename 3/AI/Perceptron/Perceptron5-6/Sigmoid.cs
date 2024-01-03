using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusivelyOrAISolving
{
    public static class Sigmoid
    {
        public static double CalculateOutput(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double CalculateDerivative(double x)
        {
            return x * (1 - x);
        }
    }
}