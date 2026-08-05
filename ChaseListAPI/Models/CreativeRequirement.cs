namespace ChaseListAPI.Models;


public class CreativeRequirement
{
    public int Number { get; set; }

    public string ProductionFileName { get; set; } = string.Empty;

    public string WorkingFileName { get; set; } = string.Empty;

    public string Phase { get; set; } = string.Empty;

    public string Platform { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Dimensions { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}