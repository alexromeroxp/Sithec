using Sithec.Models;

namespace Sithec.Interfaces
{
    public interface IMathService
    {
        MathResult GetResultOfOperations(string operator1, string operator2, string operator3);

        double CalculateSum(double num1, double num2, double num3);
        double CalculateDifference(double num1, double num2, double num3);
        double CalculateProduct(double num1, double num2, double num3);
        double CalculateQuotient(double num1, double num2, double num3);
    }
}
