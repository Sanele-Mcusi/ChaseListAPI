using System.IO;
using System.Linq;
using ChaseListAPI.Models;

namespace ChaseListAPI.Services;

public class ValidationService
{
    public List<ValidationResult> Validate(
        List<CreativeRequirement> requirements,
        List<ImageDetails> images)
    {
        var results = new List<ValidationResult>();

        foreach (var requirement in requirements)
        {
            var errors = new List<string>();

            // Find the uploaded image by Production Filename
            var image = images.FirstOrDefault(i =>
                Path.GetFileNameWithoutExtension(i.FileName)
                    .Equals(requirement.ProductionFileName,
                        StringComparison.OrdinalIgnoreCase));

            if (image == null)
            {
                results.Add(new ValidationResult
                {
                    FileName = requirement.ProductionFileName,
                    IsValid = false,
                    Errors = new List<string>
                    {
                        "Image not uploaded."
                    }
                });

                continue;
            }

            // Read dimensions from Excel (e.g. 1080x1080)
            var dimensions = requirement.Dimensions.Split('x');

            if (dimensions.Length != 2)
            {
                errors.Add("Invalid dimensions format in chase list.");
            }
            else
            {
                if (int.TryParse(dimensions[0], out int expectedWidth) &&
                    int.TryParse(dimensions[1], out int expectedHeight))
                {
                    if (image.Width != expectedWidth)
                    {
                        errors.Add($"Expected width {expectedWidth}px but received {image.Width}px.");
                    }

                    if (image.Height != expectedHeight)
                    {
                        errors.Add($"Expected height {expectedHeight}px but received {image.Height}px.");
                    }
                }
                else
                {
                    errors.Add("Unable to read dimensions from chase list.");
                }
            }

            // Return validation result
            results.Add(new ValidationResult
            {
                FileName = requirement.ProductionFileName,
                IsValid = errors.Count == 0,
                Errors = errors
            });
        }

        return results;
    }
}