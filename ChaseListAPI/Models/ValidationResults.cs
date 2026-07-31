namespace ChaseListAPI.Models;

public class ValidationResult
{
    public string FileName { get; set; } = string.Empty;

    public bool IsValid { get; set; }

    public List<string> Errors { get; set; } = new();
}