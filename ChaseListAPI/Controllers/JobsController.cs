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
        private readonly ExcelService _excelService;
        private readonly ImageServices _imageServices;
        private readonly ValidationService _validationService;
        public JobsController(ExcelService excelService, ImageServices imageServices, ValidationService validationService)
        {
            _excelService = excelService;
            _imageServices = imageServices;
            _validationService = validationService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] JobuploadRequest request)
        {
         
            var imageDetails = await _imageServices.GetImageInfoAsync(request.Images);
            var excelRequirements = await _excelService.ReadRequirementsAsync(request.ExcelFile);
            var validationResults = _validationService.Validate(excelRequirements, imageDetails);

            // Handle file upload logic here
            return Ok(new
            {
                message = "Files uploaded successfully.",
                ExcelFile = request.ExcelFile.FileName,
                Images = imageDetails,
                ExcelRequirements = excelRequirements,
                ValidationResults = validationResults
            });
        }
    }
}