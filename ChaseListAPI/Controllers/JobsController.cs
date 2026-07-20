//only recives files 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChaseListAPI.Models;
using SixLabors.ImageSharp;
using ChaseListAPI.Services;

namespace ChaseListAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
       private readonly ImageServices _imageServices;
       public JobsController(ImageServices imageServices)
        {
            _imageServices = imageServices;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] JobuploadRequest request)
        {
            var imageDetails = await _imageServices.GetImageInfoAsync(request.Images);

            // Handle file upload logic here
            return Ok(new
            {
                message = "Files uploaded successfully.",
                ExcelFile = request.ExcelFile.FileName,
                Images = imageDetails
            });
        }
    }
}