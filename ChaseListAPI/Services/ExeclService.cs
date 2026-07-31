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
        var requirement = new CreativeRequirement
        {
            Number = row.Cell(1).GetValue<int>(),
            ProductionFileName = row.Cell(2).GetValue<string>() ?? string.Empty,
            WorkingFileName = row.Cell(3).GetValue<string>() ?? string.Empty,
            Phase = row.Cell(4).GetValue<string>() ?? string.Empty,
            Platform = row.Cell(5).GetValue<string>() ?? string.Empty,
            Format = row.Cell(6).GetValue<string>() ?? string.Empty,
            Dimensions = row.Cell(7).GetValue<string>() ?? string.Empty,
            Description = row.Cell(8).GetValue<string>() ?? string.Empty,
            Status = row.Cell(9).GetValue<string>() ?? string.Empty
        };

        requirements.Add(requirement);
    }

    return requirements;
}
}