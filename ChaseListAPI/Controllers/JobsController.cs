//only recives files 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChaseListAPI.Models;

namespace ChaseListAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] JobuploadRequest request)
        {
            // Handle file upload logic here
            return Ok(new
            {
                message = "Files uploaded successfully.",
                ExcelFile = request.ExcelFile.FileName,
                Images = request.Images.Count
            });
        }
    }
}