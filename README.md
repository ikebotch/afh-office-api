# AFH Office Location Feed – Backend API

This is the backend API for the AFH Office Location Feed project. It fetches and paginates office location data from an external public API and exposes it via a RESTful .NET Core Web API endpoint.

---

## Features

- Connects to AFH's public office location API
- Provides paginated office location results
- Validates page indexes and ranges
- Error handling with structured responses
- Logging with reference IDs for traceability
- Swagger UI for local testing and inspection

---

## Technology Stack

- ASP.NET Core Web API (.NET 8)
- C#
- HttpClient
- ILogger for logging
- Swagger (Swashbuckle)

---

## Prerequisites

- .NET 8 SDK
- Visual Studio / Rider / VS Code
- Optional: Postman or Swagger for testing

