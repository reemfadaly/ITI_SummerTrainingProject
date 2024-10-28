using Microsoft.AspNetCore.Mvc;

namespace STDemo1.Controllers
{
    public class TestController : Controller
    {
        public string Display()
        {
            return "Hello";
        }

        public ViewResult Show()
        {
            return View();
        }
    }
}
