# StockApp

StockApp is a .NET project for Azure Functions using the isolated worker model.

# Summary of Layers

| **Layer**         | **Representation in Project**                           | **Responsibilities**                                           |
|-------------------|---------------------------------------------------------|---------------------------------------------------------------|
| **Presentation**  | `StockApp.Client`, `StockApp.Pwa`, `StockApp.API.Controllers`            | UI, client interactions, and API endpoint exposure             |
| **Application**   | `StockApp.Api`                                      | Business logic, use cases, and application coordination         |
| **Domain**        | `StockApp.Shared.Models`, `StockApp.Shared.Enums`        | Core business models and domain logic                          |
| **Infrastructure**| `StockApp.Api.Services`, `Swa.Auth.Standard` | External API calls, background tasks, and infrastructure concerns|

## Design - Overview
```mermaid
---
title: Integrating a Third-Party API in ASP.NET Web API Project
---

flowchart TD
    User([User])-->|Calls|App
    App-->|Integrates|Consumer([Consumer])
    Consumer-->|Requests|API
    API-->|Accesses|API_Provider([API Provider])
    API-->|Accesses|NoSQL[(NoSQL)]
    style User stroke:Blue,stroke-width:2px
    style App stroke:Indigo,stroke-width:2px
    style Consumer stroke:Green,stroke-width:2px
    style API stroke:Orange,stroke-width:2px
    style API_Provider stroke:Red,stroke-width:2px