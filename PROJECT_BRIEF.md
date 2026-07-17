# PROJECT_BRIEF.md - Requirements Grooming and Approval Platform

> Last updated: 2026-07-10 | Sprint 1 | Status: In Progress
> orchestrationVersion: 1.0.0

## 1. Project Overview

This project is a web application where stakeholders can submit, review, refine, and approve project requirements in a controlled workflow. The platform will centralize requirement conversations, decisions, approvals, and version history. The primary goal is to reduce ambiguity before development starts and produce an implementation-ready backlog for engineering and QA teams.

## 2. Concept / Product Description

The product supports a full requirement lifecycle:

- Stakeholders create requirements with business context, acceptance criteria, and priority.
- Product and engineering teams groom requirements through comments, clarifications, and status transitions.
- Approvers can approve, reject, or request changes with mandatory rationale.
- Approved requirements are converted into backlog items and sprint candidates.
- Audit-friendly timeline tracks who changed what and when.

Core user roles:

- Stakeholder: creates and updates business requirements.
- Product Owner: validates scope and prioritization.
- Dev Lead: checks technical feasibility and dependencies.
- QA Lead: validates testability and acceptance quality.
- Approver: final sign-off authority.

## 3. Tech Stack

- Frontend: ASP.NET MVC views (Razor), Bootstrap 5, vanilla JavaScript
- Backend: ASP.NET Core MVC (.NET 8), C#
- Hosting: Containerized deployment (Azure App Service or equivalent)
- Data: SQL Server with Entity Framework Core
- Testing: xUnit, FluentAssertions, Playwright for E2E
- CI/CD: GitHub Actions with environment-based deployment

## 4. Architecture

```text
[Browser]
   |
   v
[ASP.NET Core MVC Web App]
   |  Controllers -> Services -> Repositories
   v
[SQL Server]

Cross-cutting: AuthN/AuthZ, Audit logging, Notification service
```

## 5. Key Files Map

| Area | Path | Contents |
|------|------|----------|
| App entry | src/RequirementsGrooming.Web/Program.cs | ASP.NET app startup |
| MVC features | src/RequirementsGrooming.Web/Controllers/ | UI/API actions |
| Domain logic | src/RequirementsGrooming.Application/ | Use cases and business rules |
| Data access | src/RequirementsGrooming.Infrastructure/ | EF Core DbContext and repos |
| Tests | tests/ | Unit, integration, E2E tests |
| Sprint docs | docs/sprint-1/ | Plan, progress, done |

## 6. Team Roles

| Role | Name | Responsibility |
|------|------|----------------|
| Producer | Remy | Planning, coordination, merges |
| Product | Kira | Requirement quality and UX flow |
| Frontend | Raga | MVC views and client interactions |
| Backend | Susa | Domain, workflow, persistence |
| QA | Ivy | Test strategy and sign-off |
| DevOps | Dash | CI/CD, environments, release safety |

## 7. Sprint Status

| Sprint | Name | Status | Scope |
|--------|------|--------|-------|
| 0 | Plugin and process setup | Done | Team orchestration, templates, profiles |
| 1 | Requirement workflow MVP | In Progress | Create, groom, approve, backlog export |

## 8. Current State

What works:
- Team orchestration plugin is set up under plugin/.
- Delivery templates for sprint planning and quality gates are ready.
- ASP.NET MVC solution skeleton with layered projects is scaffolded under src/ and tests/.
- Requirement create/list/detail UI and workflow transition starter logic are implemented.
- CI workflow file is available at .github/workflows/ci-cd.yml.

What does not work yet:
- Authentication and role-based authorization are not implemented.
- SQL Server migrations and production-ready persistence setup are pending.
- Backlog export, comments, and full audit timeline are pending.

What is next:
- Implement stakeholder and approver role policies.
- Add backlog export and richer grooming/comment flows.
- Expand QA automation and staging deployment gates.

## 9. Security Rules

1. Secrets in environment variables or secret manager only.
2. Role-based authorization is required for create/update/approve actions.
3. All approval actions and requirement changes are audit logged.
4. Input validation and output encoding are mandatory to prevent injection/XSS.

## 10. How to Run Locally

```bash
dotnet restore src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
dotnet build src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
dotnet run --project src/RequirementsGrooming.Web/RequirementsGrooming.Web.csproj
```

## 11. How to Deploy

- Build and test via GitHub Actions on pull request and main branch.
- Deploy to staging on merge to main.
- Run smoke tests on staging.
- Manual approval gate for production deployment.
- Rollback via previous successful artifact/image.

## 12. Cross-Chat Handoff Protocol

1. Update docs/sprint-1/progress.md after each phase.
2. At sprint close, complete docs/sprint-1/done.md.
3. Rewrite sections 7 and 8 in this file after every sprint.
4. Keep issue links and PR links in progress notes for continuity.

## 13. Bug and Fix Tracking

- All defects tracked as GitHub Issues.
- Required labels: bug, severity:blocker/major/minor.
- Dev commits must reference issues with Fixes #ID or Refs #ID.
- QA closes issues only after verification on target environment.

## 14. Multi-Repo Setup

- Each team can work in separate clone or branch-isolated workspace.
- Branch model:
  - feature/sprint-1 for implementation
  - feature/qa-1 for QA artifacts/tests
  - feature/devops-1 for pipeline and infra updates
- Merge policy: regular merge only, no squash or rebase for sprint branches.
