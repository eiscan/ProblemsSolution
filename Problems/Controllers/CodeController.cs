using Microsoft.AspNetCore.Mvc;

namespace Problems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        [HttpGet]
        [Route("Generate")]
        public IActionResult Generate()
        {
            var generate = new GenerateCode.GenerateCode();
            return Ok(generate.GenerateCodes());
        }
    }
}
