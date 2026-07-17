# Requirements Grooming App - Dev Quick Start

## Build and Run

1. dotnet restore src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
2. dotnet ef database update --project src/RequirementsGrooming.Infrastructure/RequirementsGrooming.Infrastructure.csproj --startup-project src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
3. dotnet build src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
4. dotnet run --project src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj

## Test

- dotnet test tests/RequirementsGrooming.Tests/RequirementsGrooming.Tests.csproj

## Migrations

- Create new migration:
	dotnet ef migrations add <MigrationName> --project src/RequirementsGrooming.Infrastructure/RequirementsGrooming.Infrastructure.csproj --startup-project src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
- Apply migrations:
	dotnet ef database update --project src/RequirementsGrooming.Infrastructure/RequirementsGrooming.Infrastructure.csproj --startup-project src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj

## Current Scope

- Requirement create/list/detail
- Workflow transitions: Draft -> InReview -> Groomed -> Approved or Rejected
- Local SQLite DB file (`requirements-grooming.db`)
- ASP.NET Identity login with local role-based users

## Seeded Local Users

- stakeholder@local.dev / P@ssword123
- productowner@local.dev / P@ssword123
- approver@local.dev / P@ssword123
- devlead@local.dev / P@ssword123
- qa@local.dev / P@ssword123
- devops@local.dev / P@ssword123
