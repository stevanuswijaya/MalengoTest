using MalengoTestApplication.Hubs;
using MalengoTestApplication.BusinessLogic;
using MalengoTestApplication.Models;
using System.Web.Http.Results;
using System.Web.Http;
using System.Threading;
using MalengoTestApplication.BusinessLogic.Interface;

namespace MalengoTestApplication.Controllers
{
    [RoutePrefix("api/Palindrome")]
    public class PalindromeController : ControllerWithHub<SignalRHub>
    {
        private readonly IPalindromeFactory _palindromefactory;

        public PalindromeController(IPalindromeFactory palindromeFactory)
        {
            _palindromefactory = palindromeFactory;
        }

        // GET api/Palindrome
        [HttpGet]
        public JsonResult<PalindromeViewModel> Get(int minLength = 5, int maxLength = 10, int maxCapacity = 10)
        {
            PalindromeViewModel.Instance.IsGenerated = true;
            PalindromeViewModel returnValue = null;

            while (PalindromeViewModel.Instance.IsGenerated == true)
            {
                returnValue = _palindromefactory.PopulatePalindromeString(minLength, maxLength, maxCapacity);

                //I added sleep so you can see the palindrome is generated, because if not, 
                //it's generated really fast to the client view
                Thread.Sleep(1000);

                Hub.Clients.All.populateOnePalindrome(returnValue);
            }


            return Json(returnValue);
        }
    }
}