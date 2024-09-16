# StockApp

StockApp is a .NET project for Azure Functions using the isolated worker model.

# Summary of Layers

| **Layer**         | **Representation in Project**                           | **Responsibilities**                                           |
|-------------------|---------------------------------------------------------|---------------------------------------------------------------|
| **Presentation**  | `StockApp.Client`, `StockApp.API.Controllers`            | UI, client interactions, and API endpoint exposure             |
| **Application**   | `StockApp.Services`                                      | Business logic, use cases, and application coordination         |
| **Domain**        | `StockApp.Shared.Models`, `StockApp.Shared.Enums`        | Core business models and domain logic                          |
| **Infrastructure**| `StockApp.Functions`, `StockApp.Services.Implementations`| External API calls, background tasks, and infrastructure concerns|
