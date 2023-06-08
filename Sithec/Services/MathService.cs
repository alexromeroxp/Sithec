using Sithec.Interfaces;
using Sithec.Models;



public class MathService : IMathService
{

    public MathResult GetResultOfOperations(string operator1, string operator2, string operator3)
    {
        if (double.TryParse(operator1, out var Operator1) && double.TryParse(operator2, out var Operator2) && double.TryParse(operator3, out var Operator3))
                {
                    MathResult result = new MathResult
                    {
                        Sum = CalculateSum(Operator1, Operator2, Operator3),
                        Difference = CalculateDifference(Operator1, Operator2, Operator3),
                        Product = CalculateProduct(Operator1, Operator2, Operator3),
                        Quotient = CalculateQuotient(Operator1, Operator2, Operator3)
                    };
                    return result;
                }
        return new MathResult { };
    }

    public double CalculateSum(double num1, double num2, double num3)
    {
        return num1 + num2 + num3;
    }

    public double CalculateDifference(double num1, double num2, double num3)
    {
        return num1 - num2 - num3;
    }

    public double CalculateProduct(double num1, double num2, double num3)
    {
        return num1 * num2 * num3;
    }

    public double CalculateQuotient(double num1, double num2, double num3)
    {
        if (num2 != 0 && num3 != 0)
        {
            return num1 / num2 / num3;
        }

        throw new DivideByZeroException("Division by zero is not allowed.");
    }
}
