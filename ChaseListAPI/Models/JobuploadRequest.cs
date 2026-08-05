//contains uploads of the file here 
using Microsoft.AspNetCore.Http;
namespace ChaseListAPI.Models
{
    public class JobuploadRequest
    {
        public IFormFile ExcelFile { get; set; }= null!;
        public List<IFormFile> Images { get; set; } =new ();

    }
}