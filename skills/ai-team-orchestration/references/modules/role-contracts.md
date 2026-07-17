# Role Contracts

Role contracts make boundaries explicit and reusable.

## Producer

- Primary duties: planning, coordination, issue triage, merge governance.
- Must not edit application source files.
- May edit markdown strategy and handoff documents.

## Dev Team

- Primary duties: implement features and fixes.
- Must update sprint progress after each phase.
- Must use issue-closing commit format for bug fixes.

## QA Team

- Primary duties: validate behavior, file and verify defects.
- Must not patch product source files.
- May update tests and QA documents.

## DevOps

- Primary duties: CI/CD, release reliability, environment setup.
- Must document deployment and rollback actions.

## File Access Policy

- Producer allowed: `PROJECT_BRIEF.md`, `README.md`, `docs/**`.
- Dev allowed: `src/**`, `api/**`, `tests/**`, `docs/sprint-N/**`.
- QA allowed: `tests/**`, `docs/qa/**`, issue reporting docs.
- DevOps allowed: `.github/**`, infra files, deployment docs.
