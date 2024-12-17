using System.ServiceModel;

namespace SOAPMathsService.BusinessLogic
{
    [ServiceContract]
    public interface ISoapService
    {
        [OperationContract]
        string Addition(int num1, int num2);

        [OperationContract]
        string Subtraction(int num1, int num2);

        [OperationContract]
        string Multiplication(int num1, int num2);

        [OperationContract]
        string Division(int num1, int num2);

        [OperationContract]
        int Sum(int num1, int num2);
        [OperationContract]
        int Sub(int num1, int num2);
        [OperationContract]
        int Mul(int num1, int num2);
        [OperationContract]
        int Div(int num1, int num2);
    }
    public class SOAPMathsOperationService : ISoapService
    {
        public string Addition(int num1, int num2)
        {
            return $"Addition of two number is: {num1 + num2}";
        }

        public string Subtraction(int num1, int num2)
        {
            return $"Subtraction of two number is: {num1 - num2}";
        }

        public string Multiplication(int num1, int num2)
        {
            return $"Multiplication of two number is: {num1 * num2}";
        }
        public string Division(int num1, int num2)
        {
            return $"Division of two number is: {num1 / num2}";
        }

        public int Sum(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }
        public int Sub(int num1, int num2)
        {
            int sub = num1 - num2;
            return sub;
        }
        public int Mul(int num1, int num2)
        {
            int mul = num1 * num2;
            return mul;
        }
        public int Div(int num1, int num2)
        {
            int div = num1 / num2;
            return div;
        }
    }
}
