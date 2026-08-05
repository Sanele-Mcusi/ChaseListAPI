# ChaseListAPI

A minimal ASP.NET Core 10 Web API for uploading an Excel file and related images in a single request.

## Version 1 Progress

### ✅ Version 1 Progress

- ✔ ASP.NET Core Web API
- ✔ Swagger
- ✔ Upload Excel
- ✔ Upload multiple images
- ✔ Read Excel into `CreativeRequirement`
- ✔ Read image metadata into `ImageDetails`
- 🔷 Validation stage in progress (`ValidationService` exists, rules can be added next)

## Project structure

- [ChaseListAPI/ChaseListAPI.csproj](ChaseListAPI/ChaseListAPI.csproj) - project file.
- [ChaseListAPI/Program.cs](ChaseListAPI/Program.cs) - startup and middleware configuration.
- [ChaseListAPI/Controllers/JobsController.cs](ChaseListAPI/Controllers/JobsController.cs) - file upload endpoint.
- [ChaseListAPI/Models/JobuploadRequest.cs](ChaseListAPI/Models/JobuploadRequest.cs) - request model for uploads.

## Features

- Accepts one Excel file and multiple images in a `multipart/form-data` request.
- Swagger/OpenAPI is enabled in development for quick testing.

## Requirements

- .NET 10 SDK

## Getting started

1. Open the project in your IDE (VS Code recommended).
2. Restore packages and build:

```bash
cd "ChaseListAPI/ChaseListAPI"
dotnet restore
dotnet build
```

## Run the API

Start the app (from repo root or project folder):

```bash
dotnet run --project "ChaseListAPI/ChaseListAPI.csproj"
```

When running in the development environment, Swagger UI is available at `https://localhost:<port>/swagger`.

## Upload endpoint

- Endpoint: `POST /api/jobs`
- Content type: `multipart/form-data`
- Form fields:
  - `ExcelFile` (file) - the Excel file to upload
  - `Images` (file[]) - one or more image files

### Example `curl` (multipart/form-data)

Replace `<port>` with the port reported by `dotnet run`.

```bash
curl -k -X POST "https://localhost:<port>/api/jobs" \
  -F "ExcelFile=@/path/to/list.xlsx" \
  -F "Images=@/path/to/image1.jpg" \
  -F "Images=@/path/to/image2.png"
```

### Sample JSON response

```json
{
  "message": "Files uploaded successfully.",
  "ExcelFile": "list.xlsx",
  "Images": 2
}
```

## Testing with Swagger

Run the API in development and open the Swagger UI at `https://localhost:<port>/swagger` to try the `POST /api/jobs` endpoint using the interactive form.

## Notes & next steps

- Currently the API returns a confirmation and does not persist uploaded files. To store files add logic in `JobsController.UploadFile`.
- Excel validation in `Services/ExeclService.cs` now requires column A to contain a valid integer. Empty A cells are skipped, and non-numeric values are ignored to avoid parsing errors.
- Consider adding a storage implementation (local disk, Azure Blob, or S3) and input validation for file size/type.

If you'd like, I can add a `curl` command with an example Excel and image, create a Postman collection, or implement simple local storage handling in the controller.
