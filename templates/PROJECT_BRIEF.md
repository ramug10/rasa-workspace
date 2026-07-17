# PROJECT_BRIEF.md - [Project Name]

> Last updated: [date] | Sprint [N] | Status: [In Progress / Complete]
> orchestrationVersion: [1.x]

## 1. Project Overview

[3-4 sentences describing what the project is, who it is for, and the core goal.]

## 2. Concept / Product Description

[Detailed description of user flows, major features, and product intent.]

## 3. Tech Stack

- Frontend: [framework, language, key libraries]
- Backend: [runtime, framework, database]
- Hosting: [platform, CDN, storage]
- Testing: [test framework, E2E tool]
- CI/CD: [pipeline tool]

## 4. Architecture

```text
[Frontend] -> HTTPS -> [Backend API] -> [Database/Storage]
```

## 5. Key Files Map

| Area | Path | Contents |
|------|------|----------|
| Entry point | src/main.tsx | App bootstrap |
| API | api/src/ | Server-side logic |
| Config | api/src/config/ | Server-only configuration |
| Tests | tests/ | E2E and API tests |
| Sprint docs | docs/sprint-N/ | Plans, progress, done |

## 6. Team Roles

| Role | Name | Responsibility |
|------|------|----------------|
| Producer | [name] | Planning, coordination, merges |
| Frontend | [name] | UI and client logic |
| Backend | [name] | API, auth, data |
| QA | [name] | Testing and sign-off |
| DevOps | [name] | CI/CD and deployment |

## 7. Sprint Status

| Sprint | Name | Status | Scope |
|--------|------|--------|-------|
| 0 | Setup | Done | Template and architecture setup |

## 8. Current State

What works:
- [working feature]

What does not work yet:
- [known issue]

What is next:
- [next sprint goal]

## 9. Security Rules

1. Secrets live in environment variables only.
2. Inputs are validated server-side.
3. Sensitive data is never logged.

## 10. How to Run Locally

```bash
npm install
cd api && npm install
npm run dev:all
```

## 11. How to Deploy

[Pipeline and environment strategy with rollback references.]

## 12. Cross-Chat Handoff Protocol

1. Write done summary at sprint close.
2. Update sprint tracker and current state.
3. Commit with descriptive sprint summary.

## 13. Bug and Fix Tracking

- Bugs are tracked as GitHub Issues.
- QA applies severity labels.
- Dev uses issue-closing commit keywords.

## 14. Multi-Repo Setup

- Teams use separate clones.
- Feature branch -> PR -> regular merge to main.
- No squash merge, no rebase on shared feature work.
