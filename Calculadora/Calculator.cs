using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Calculator
{
   public static double Operacao(double A, double B, string op)
    {
        //variavel resultado
        double result = double.NaN;

        //Switch para digitar uma opção
        switch (op)
        {
            case "a":
                result = A + B;
                break;
            case "b":
                result = A - B;
                break;
            case "c":
                if (B != 0)
                {
                    result = A / B;
                }
                break;
            case "d":
                result = A * B;
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
}
