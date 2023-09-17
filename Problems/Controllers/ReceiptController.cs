using Microsoft.AspNetCore.Mvc;
using Problems.Dtos;
using Problems.Receipt;
using System.Linq;

namespace Problems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        [HttpPost]
        [Route("Read")]
        public IActionResult Read(ReceiptRequestDto[] requestDto)
        {            
            ReadingReceipt readingReceipt = new ReadingReceipt();
            return Ok(readingReceipt.Read(requestDto.ToList()));
        }
    }
}
