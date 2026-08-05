
namespace ChaseListAPI.Models;

public class ImageDetails
{
    public string FileName { get; set; } = string.Empty;
    public int Width { get; set; }     
    public int Height { get; set; } 
    public long Filesize { get; set; }
    public string Format { get; set; } = string.Empty;
}