using Microsoft.AspNetCore.Mvc;
using SOAPMathsOperationServiceReference;
using SOAPMathsServiceConsumerWebApp.Models;
using System.Diagnostics;

namespace SOAPMathsServiceConsumerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ISoapService soapServiceChannel = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
            var sumResponse = await soapServiceChannel.AdditionAsync(new AdditionRequest()
            {
                Body = new AdditionRequestBody()
                {
                    num1 = 5,
                    num2 = 2
                }
            });
            Console.WriteLine(sumResponse.Body.AdditionResult);


            var subResponse = await soapServiceChannel.SubtractionAsync(new SubtractionRequest()
            {
                Body = new SubtractionRequestBody()
                {
                    num1 = 5,
                    num2 = 2
                }
            });
            Console.WriteLine(subResponse.Body.SubtractionResult);


            var mulResponse = await soapServiceChannel.MultiplicationAsync(new MultiplicationRequest()
            {
                Body = new MultiplicationRequestBody()
                {
                    num1 = 5,
                    num2 = 2
                }
            });
            Console.WriteLine(mulResponse.Body.MultiplicationResult);
            var divResponse = await soapServiceChannel.DivisionAsync(new DivisionRequest()
            {
                Body = new DivisionRequestBody()
                {
                    num1 = 5,
                    num2 = 2
                }
            });
            Console.WriteLine(divResponse.Body.DivisionResult);
            /*
            var op = new Operations();
            try
            {
                op.Sum = sumResponse.Body.SumResult;
                op.Sub = subResponse.Body.SubResult;
                op.Mul = mulResponse.Body.MulResult;
                op.Div = divResponse.Body.DivResult;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }*/

            var sum = await soapServiceChannel.SumAsync(5, 2);
            Console.WriteLine($"Addition of two number is: " + sum);


            var sub = await soapServiceChannel.SubAsync(5, 2);
            Console.WriteLine($"Subtraction of two number is: " + sub);


            var mul = await soapServiceChannel.MulAsync(5, 2);
            Console.WriteLine($"Multiplication of two number is: " + mul);
            var div = await soapServiceChannel.DivAsync(5, 2);
            Console.WriteLine($"Division of two number is: " + div);
            var op = new Operations();
            try
            {
                op.Sum = sum;
                op.Sub = sub;
                op.Mul = mul;
                op.Div = div;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return View(op);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
