using MalengoTestApplication.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace MalengoTestApplication.Controllers
{
    [RoutePrefix("api/StopPalindrome")]
    public class StopPalindromeController : ApiController
    {
        // GET: api/StopPalindrome
        [HttpGet]
        public JsonResult<PalindromeViewModel> Get()
        {
            PalindromeViewModel.Instance.IsGenerated = false;
            return Json(PalindromeViewModel.Instance);
        }
    }
}
