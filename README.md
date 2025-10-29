# API with NUnit and Code Coverage

A robust ASP.NET Core Web API for managing categories with complete CRUD operations, built using Entity Framework Code-First and automated migrations. Includes a comprehensive NUnit test suite and integrated code coverage reporting using Coverlet and ReportGenerator.

## Features
- ASP.NET Core API structure
- Entity Framework code-first migrations
- NUnit integration with test samples
- Code coverage reports (Coverlet + ReportGenerator)
- Database seeding and migration scripts included

## Getting Started
1. Clone the repository  
2. Run `dotnet restore` to install dependencies  
3. Apply migrations: `dotnet ef database update`  
4. Run tests with coverage: `dotnet test --collect:"XPlat Code Coverage"`  
5. View coverage report in `/TestResults/CoverageReport/index.html`
6. <img width="1676" height="952" alt="image" src="https://github.com/user-attachments/assets/b810d6d4-78a5-4e42-a864-5239c9c18813" />


## Usage
Use the provided API endpoints for category management. Explore tests and coverage reports for quality assurance.

## Contributing
Contributions and suggestions are welcome!

## License
MIT License
