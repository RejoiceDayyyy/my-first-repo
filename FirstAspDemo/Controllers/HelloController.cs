using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FirstAspDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        //GET /hello
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello! 这是我的第一个ASP.NET Core API Demo");
        }

        //GET /hello/{name}
        [HttpGet("{name}")]
        public IActionResult GetWithName(string name)
        {
            return Ok($"你好，{name}！欢迎来到ASP.NET Core 的世界！");
        }
    }
}
