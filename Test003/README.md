# Test 003 - Shop Management

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)][![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fvosonha89%2Fnetcore-api-base.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fvosonha89%2Fnetcore-api-base?ref=badge_shield)
()
[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-white.svg)](https://sonarcloud.io/summary/new_code?id=Top.MasonTech.NetCoreBaseAPI)
[![SonarLint](https://img.shields.io/badge/SonarLint-Enabled-brightgreen)](https://www.sonarlint.org/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A clean architecture-based .NET 8.0 Web API template for building modern, maintainable web services. This project implements a comprehensive foundation for building production-ready APIs with best practices and industry standards baked in.

## Project Overview

This project implements Clean Architecture (also known as Onion Architecture) to provide a scalable and testable foundation for web APIs. It separates concerns into distinct layers with clear dependency directions, ensuring that business logic remains independent of external frameworks and implementation details.

## 🏗️ Architecture

The project follows Clean Architecture principles with the following layers:

### Core

#### Domain Layer

Contains enterprise business rules and entities that represent the core business logic independent of application specifics.

- Business entities and value objects
- Domain logic and validation rules
- Domain events and services
- Repository interfaces

#### Application Layer

Contains application logic that orchestrates the flow of data to and from domain entities.

- Use cases implementation
- DTOs (Data Transfer Objects)
- Interfaces for infrastructure
- Mappers between layers
- Service implementations

### Infrastructure

- **Persistence**: Database access, repository implementations
- **External**: Integration with external services and APIs

### Presentation

- **APIs**: RESTful API controllers with Swagger documentation
- **Views**: Razor views (if applicable)

## ✨ Features

- **Clean Architecture**: Domain-centric design with clear separation of concerns
- **API Documentation**: Integrated Swagger/OpenAPI with examples and authentication
- **Advanced Error Handling**: Consistent error responses with proper HTTP status codes
- **Request Validation**: Input validation using FluentValidation
- **Pagination Support**: Standardized pagination for collections
- **Filtering and Sorting**: Flexible query capabilities
- **Authentication & Authorization**: JWT-based auth with role-based permissions
- **Logging & Monitoring**: Structured logging with Serilog
- **Database Integration**: Entity Framework Core with migrations
- **Testing**: Unit, integration, and API tests with XUnit
- **CI/CD**: GitHub Actions workflow templates
- **Code Quality**: SonarCloud and SonarLint integration
- **Docker Ready**: Containerization with multi-stage builds

## 🚀 Technology Stack

- **.NET 8.0**: Latest .NET framework with performance improvements
- **ASP.NET Core**: Web API framework with minimal API support
- **Entity Framework Core**: ORM for database operations
- **FluentValidation**: Request validation
- **AutoMapper**: Object-to-object mapping
- **MediatR**: CQRS and mediator pattern implementation
- **Swagger/OpenAPI**: API documentation with versioning
- **Serilog**: Structured logging
- **xUnit**: Testing framework
- **Docker**: Containerization support
- **SonarQube/SonarLint**: Code quality analysis

## 🔧 Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022, VS Code, or JetBrains Rider (with C# extensions)
- Docker (optional for containerization)
- SQL Server/PostgreSQL (optional depending on your persistence choice)

### Installation

1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/Top.MasonTech.NetCoreBaseAPI.git
   cd Top.MasonTech.NetCoreBaseAPI
   ```

2. Restore dependencies
   ```bash
   dotnet restore
   ```

3. Set up your database connection string in `appsettings.Development.json`

4. Apply database migrations (if using Entity Framework Core)
   ```bash
   dotnet ef database update
   ```

### Running the Application

1. Build and run the application:
   ```bash
   dotnet build
   dotnet run --project Presentation/APIs/Top.MasonTech.NetCoreBaseAPI
   ```

2. Open your browser and navigate to `https://localhost:5001/swagger` to view the API documentation

### Development Workflow

1. Create a feature branch from `develop`
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. Implement your changes following the project architecture

3. Run tests to ensure code quality
   ```bash
   dotnet test
   ```

4. Create a pull request to merge your changes into `develop`

### Using Docker

```bash
# Build the Docker image
docker build -t netcore-base-api .

# Run the container
docker run -p 8080:8080 -p 8081:8081 netcore-base-api

# Or use Docker Compose
docker-compose up -d
```

## 📝 Project Structure

```
Top.MasonTech.NetCoreBaseAPI/
├── Core/                           # Core business logic
│   ├── Application/                # Application services layer
│   │   ├── DTOs/                   # Data Transfer Objects
│   │   ├── Exceptions/             # Application-specific exceptions
│   │   ├── Interfaces/             # Application interfaces
│   │   └── Serivces/               # Service implementations
│   └── Domain/                     # Domain layer (business entities and logic)
│       ├── Common/                 # Shared domain components
│       │   └── Constant/           # Constant values and enumerations
│       ├── Entities/               # Domain entities
│       ├── Exceptions/             # Domain-specific exceptions
│       └── Repositories/           # Repository interfaces
├── Infrastructure/                 # Infrastructure implementation
│   ├── Common/                     # Shared infrastructure components
│   ├── External/                   # External service integrations
│   └── Persistence/                # Data access and repositories
│       ├── Context/                # Database contexts
│       ├── Entities/               # Database entity configurations
│       ├── Migrations/             # EF Core migrations
│       └── Repositories/           # Repository implementations
├── Presentation/                   # Presentation layer
│   └── APIs/                       # API controllers and configuration
│       ├── Controllers/            # API controllers
│       ├── Extensions/             # API-specific extensions
│       ├── Filters/                # API filters
│       ├── Middleware/             # Custom middleware
│       └── Models/                 # Request/response models
├── Environment/                    # Environment-specific configurations
│   ├── appsettings.Development.json  # Development environment settings
│   ├── appsettings.Staging.json   # Staging environment settings
│   └── appsettings.Production.json  # Production environment settings
├── Tests/                          # Test projects
│   ├── UnitTests/                  # Unit tests
│   └── IntegrationTests/           # Integration tests
├── Program.cs                      # Application entry point
├── Dockerfile                      # Docker configuration
├── README.md                       # Project documentation
└── LICENSE                         # MIT License
```

## 🧪 Development Guidelines

### API Design Best Practices

#### RESTful Principles
- Use proper HTTP methods for operations (GET, POST, PUT, DELETE, PATCH)
- Design resource-oriented URLs (e.g., `/api/users` instead of `/api/getUsers`)
- Implement appropriate HTTP status codes (200, 201, 400, 401, 403, 404, 500)
- Return consistent response formats (use ProblemDetails for errors)
- Support content negotiation where appropriate

#### Performance
- Implement proper caching strategies with ETags and cache headers
- Support pagination for large datasets with standardized parameters
- Use async/await for all I/O operations
- Optimize database queries and avoid N+1 query problems
- Consider using compression for response payloads

#### Security
- Implement proper authentication and authorization
- Validate all inputs against XSS, SQL injection, etc.
- Use HTTPS only with proper certificate configuration
- Apply rate limiting and throttling for public APIs
- Follow the principle of least privilege

#### Versioning
- Support API versioning (URL, header, or content negotiation)
- Maintain backward compatibility when possible
- Document breaking changes and deprecation policy
- Use semantic versioning for API versions

### Clean Architecture Principles

1. **Independence**: Business rules don't depend on UI, database, or external frameworks
2. **Testability**: Business logic can be tested without external elements
3. **Maintainability**: Changes in external systems have minimal impact on business logic

## 🔧 Environment Setup

### Development Environment

The project includes configuration for multiple environments:

- **Development**: Local development settings
- **Staging**: Pre-production testing environment
- **Production**: Live environment configuration

Environment-specific settings are stored in `Environment/appsettings.{Environment}.json` files.

### Database Migrations

To create and apply database migrations:

```bash
# Create a new migration
dotnet ef migrations add MigrationName --project Infrastructure/Persistence --startup-project Presentation/APIs

# Apply migrations to the database
dotnet ef database update --project Infrastructure/Persistence --startup-project Presentation/APIs
```

## 📄 License

This project is licensed under the MIT License, see the [LICENSE](LICENSE) file for details.


[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fvosonha89%2Fnetcore-api-base.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fvosonha89%2Fnetcore-api-base?ref=badge_large)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

Please make sure your code follows the existing style and includes appropriate tests.

## 🏢 About MasonTech

This project template is maintained by MasonTech and provides a standardized approach to building scalable .NET Core applications following industry best practices.

For questions, feedback, or support, please contact us at support@masontech.com or visit our website at [https://masontech.com](https://masontech.com).