using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [ApiController]
    [Route("Test/[Action]")]
    public class TestController:ControllerBase
    {
       public string Get()
        {
            return "Hello Diksha";
        }

        public string Get1()
        {
            return "Hello Diksha1";
        }
    }
}
