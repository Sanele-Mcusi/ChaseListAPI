//Compares the images against the chase list and returns the result
using ChaseListAPI.Models;

namespace ChaseListAPI.Services;

public class ValidationService
{
  public List<ValidationResult> Validate(
        List<CreativeRequirement> requirements,
        List<ImageDetails> images)
    {
        var results = new List<ValidationResult>();

        return results;

    }
}