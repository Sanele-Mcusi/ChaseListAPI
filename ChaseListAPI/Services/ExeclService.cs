//reads the chaselist 
using ChaseListAPI.Models;
using ClosedXML.Excel;

namespace ChaseListAPI.Services;

public class ExcelService
{
public async Task<List<CreativeRequirement>> ReadRequirementsAsync(IFormFile excelFile)
{
    var requirements = new List<CreativeRequirement>();

    using var stream = excelFile.OpenReadStream();

    using var workbook = new XLWorkbook(stream);

   var worksheet = workbook.Worksheet("Master Creative List");

    var rows = worksheet.RowsUsed().Skip(14);

    foreach (var row in rows)
    {
        var numberCell = row.Cell(1);
        if (numberCell.IsEmpty())
        {
            // skip rows where column A is empty
            continue;
        }

        var numberText = numberCell.GetString().Trim();
        if (string.IsNullOrWhiteSpace(numberText))
        {
            continue;
        }

        if (!int.TryParse(numberText, out var number))
        {
            // skip rows where column A is not a valid integer
            continue;
        }

        var productionName = row.Cell(2).GetValue<string>()?.Trim() ?? string.Empty;
        var workingName = row.Cell(3).GetValue<string>()?.Trim() ?? string.Empty;
        var phase = row.Cell(4).GetValue<string>()?.Trim() ?? string.Empty;
        var platform = row.Cell(5).GetValue<string>()?.Trim() ?? string.Empty;
        var format = row.Cell(6).GetValue<string>()?.Trim() ?? string.Empty;
        var dimensions = row.Cell(7).GetValue<string>()?.Trim() ?? string.Empty;
        var description = row.Cell(8).GetValue<string>()?.Trim() ?? string.Empty;
        var status = row.Cell(9).GetValue<string>()?.Trim() ?? string.Empty;

        var requirement = new CreativeRequirement
        {
            Number = number,
            ProductionFileName = productionName,
            WorkingFileName = workingName,
            Phase = phase,
            Platform = platform,
            Format = format,
            Dimensions = dimensions,
            Description = description,
            Status = status
        };

        requirements.Add(requirement);
    }

    return requirements;
}
}