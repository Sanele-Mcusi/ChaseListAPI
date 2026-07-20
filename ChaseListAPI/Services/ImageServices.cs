//Reads Image (metadata)
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using ChaseListAPI.Models;


namespace ChaseListAPI.Services;
public class ImageServices
{
    
 public async Task<List<ImageDetails>> GetImageInfoAsync(List<IFormFile> images)
    {
        

        var imagesInfros = new List<ImageDetails>();

        foreach (var image in images)
        {
            using  var stream = image.OpenReadStream();
            using var ImageInfo = await Image.LoadAsync(stream);
            
            imagesInfros.Add(new ImageDetails
            {
                FileName = image.FileName,
                Width = ImageInfo.Width,
                Height = ImageInfo.Height,
                Filesize = image.Length,
                Format = ImageInfo.Metadata.DecodedImageFormat?.Name ?? "Unknown"
            });
        }
        return imagesInfros;
    }
}

   


