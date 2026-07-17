# CI/CD Pipeline Plan - Requirements Grooming Platform

## Pipeline Stages

1. Restore and build ASP.NET MVC solution
2. Run unit tests and integration tests
3. Run security and dependency checks
4. Package application artifact/container image
5. Deploy to staging environment
6. Execute staging smoke tests
7. Manual approval gate
8. Deploy to production

Baseline implementation exists in `.github/workflows/ci-cd.yml` for restore, build, and test on PR and main.

## Branch Triggers

- Pull Request: build + tests + quality checks
- Main branch merge: full pipeline to staging
- Release tag: production deployment after approval

## Required Environment Variables

- ASPNETCORE_ENVIRONMENT
- ConnectionStrings__Default
- Auth__Authority
- Auth__ClientId
- Logging__InstrumentationKey

## Rollback Plan

- Keep last three successful build artifacts
- One-click redeploy to previous artifact
- Disable unstable features via feature flags

## Ownership

- Pipeline authoring and maintenance: Dash (DevOps)
- Release approval: Producer + QA sign-off
