# StockApp

StockApp is a .NET project leveraging Azure Static Web Apps.  Azure Static Web Apps is a cloud-based modern web app service that deploys full stack web apps to Azure from a code repository.  StockApp demonstration project was created using Visual Studio 2022, .NET 8, Blazor WebAssembly, Azure Functions (isolated worker) Serverless Backend, Azure Cosmos DB - NoSQL, GitHub authentication, GitHub code repository, SWA CLI development, and Fluent UI Blazor components. 

## Features

This project uses the following technologies.

- Visual Studio 2022
- Azure Static Web Apps
- Azure Functions
- Azure Cosmos DB
- Blazor WebAssembly
- Fluent UI Blazor components

This project uses the following ASWA capabilities.

- Free Web Hosting
- Integrated API w/ Azure Functions
- GitHub CI/CD
- Free SSL Certificates
- Custom Domain
- Built-in Security w/ Github
- Azure Static Web Apps CLI (SWA CLI)

# Summary of Layers

| **Layer**         | **Representation in Project**                           | **Responsibilities**                                           |
|-------------------|---------------------------------------------------------|---------------------------------------------------------------|
| **Presentation**  | `StockApp.Client`, `StockApp.Pwa`            | UI, client interactions, and API endpoint exposure             |
| **Application**   | `StockApp.Api`                                      | Business logic, use cases, and application coordination         |
| **Domain**        | `StockApp.Shared.Models`, `StockApp.Shared.Enums`        | Core business models and domain logic                          |
| **Infrastructure**| `StockApp.Api.Services`, `Swa.Auth.Standard` | External API calls, background tasks, and infrastructure concerns|

## Design - Overview
```mermaid
---
title: Integrating a Third-Party API with an Azure Static Web Apps (Blazor WebAssembly app and .NET API)
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
    style NoSQL stroke:Red,stroke-width:2px