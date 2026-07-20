# ChaseListAPI

A simple ASP.NET Core 10 Web API for uploading an Excel file and related images in a single request.

## Project structure

- `ChaseListAPI/ChaseListAPI.csproj` - ASP.NET Core Web API project file.
- `ChaseListAPI/Program.cs` - application startup and middleware configuration.
- `ChaseListAPI/Controllers/JobsController.cs` - controller for file upload endpoint.
- `ChaseListAPI/Models/JobuploadRequest.cs` - request model for uploaded files.

## Features

- Accepts a single Excel file plus multiple images in a `multipart/form-data` request.
- Uses Swagger/OpenAPI for API documentation in development.

## Requirements

- .NET 10 SDK
- macOS or another supported OS

## Getting started

1. Open the project in VS Code or your preferred IDE.
2. Restore packages and build the project:

```bash
cd "ChaseListAPI/ChaseListAPI"
dotnet restore
dotnet build
```

## Run the API

```bash
dotnet run --project "ChaseListAPI/ChaseListAPI.csproj"
```

By default, the app runs with HTTPS and Swagger enabled in the development environment.

## API endpoints

### Upload file

- `POST /api/jobs`
- Content type: `multipart/form-data`
- Form fields:
  - `ExcelFile` - the Excel file to upload
  - `Images` - one or more image files

Example request body fields:

- `ExcelFile` = `file.xlsx`
- `Images` = `image1.png`, `image2.jpg`, etc.

### Sample response

```json
{
  "message": "Files uploaded successfully.",
  "ExcelFile": "example.xlsx",
  "Images": 2
}
```

## Swagger

When running in development, open the Swagger UI at:

```
https://localhost:<port>/swagger
```

## Notes

- The API currently returns a simple confirmation response and does not persist uploads.
- Add storage or processing logic in `JobsController.UploadFile` to handle the uploaded files.
