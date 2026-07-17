# Sprint 1 - Done

## What Was Built

- ASP.NET MVC layered solution skeleton (web/application/domain/infrastructure/tests)
- Requirement workflow: create, edit (draft), list, details, submit for review, mark groomed, approve, reject
- Backlog export endpoint for approved requirements
- Header-based role guard for protected workflow and approval actions
- Unit test baseline for create/update/approve/reject transition behaviors
- CI pipeline baseline for restore, build, test, publish, and artifact upload

## What Is Not Done

- Full authentication and identity integration
- SQL migration scripts and seeded environments
- Comments/clarification thread and detailed audit timeline UI

## Files Changed or Created

- PROJECT_BRIEF.md - project baseline and governance
- docs/sprint-1/* - sprint execution artifacts

## Manual Setup Required

- Configure ConnectionStrings:Default for SQL Server (optional now; in-memory fallback is enabled)
- Provide header X-User-Role in requests when testing protected actions

## Known Issues

- Header-based role check is a temporary MVP control, not production auth
