# AI Team Orchestration Plugin

Reusable multi-agent delivery plugin for software engineering teams.

## Current Version State

- Plugin release: `1.2.0` (see `plugin/CHANGELOG.md`)
- Orchestration contract: `1.1.0` (`plugin/orchestration.config.yaml`)
- Schema: `plugin/schema/orchestration.config.schema.json`

## What Is Included

- `plugin/agents/` - role agents and specialized control agents
- `plugin/skills/ai-team-orchestration/` - orchestration workflow skill and references
- `plugin/templates/` - project and sprint document templates
- `plugin/profiles/` - profile presets (`web-app`, `api-only`, `data-app`)
- `plugin/schema/` - config schema validation contract
- `plugin/orchestration.config.yaml` - project-level orchestration settings

## Agent Catalog

Core team agents:

- `plugin/agents/ai-team-workforce.agent.md` - sprint planning, coordination, triage, merge governance
- `plugin/agents/ai-team-dev.agent.md` - implementation across frontend/backend/visual roles
- `plugin/agents/ai-team-qa.agent.md` - testing, bug reporting, sprint sign-off
- `plugin/agents/ai-team-devops.agent.md` - CI/CD, deployment safety, rollback, and operational reliability

Specialized control agents:

- `plugin/agents/ai-team-security-gatekeeper.agent.md` - security merge/release guardrail enforcement
- `plugin/agents/ai-team-release-reliability.agent.md` - release go/no-go, rollback readiness, post-release verification
- `plugin/agents/ai-team-delivery-intelligence.agent.md` - success metrics analysis, drift detection, corrective actions

Lifecycle usage guide:

- `plugin/skills/ai-team-orchestration/SKILL.md` (section: Specialized Agent Invocation Guide)

## Very Simple Quick Start

### A) Start with a New Project

1. Copy `plugin/` into your repo root.
2. Edit `plugin/orchestration.config.yaml`:
   - set `project.name`
   - choose `profile` (`web-app`, `api-only`, or `data-app`)
3. Create sprint docs from templates:
   - `plugin/templates/PROJECT_BRIEF.md` -> `PROJECT_BRIEF.md`
   - `plugin/templates/docs/sprint-N/plan.md` -> `docs/sprint-1/plan.md`
   - `plugin/templates/docs/sprint-N/progress.md` -> `docs/sprint-1/progress.md`
   - `plugin/templates/docs/sprint-N/done.md` -> `docs/sprint-1/done.md`
   - `plugin/templates/docs/sprint-N/success-paths.md` -> `docs/sprint-1/success-paths.md`
   - `plugin/templates/docs/qa/sprint-N-signoff.md` -> `docs/qa/sprint-1-signoff.md`
4. Start the process using `plugin/skills/ai-team-orchestration/SKILL.md`.

### B) Add Plugin to an Existing Project

1. Copy `plugin/` into your existing repo.
2. Keep your current source code as-is.
3. Create only the orchestration docs:
   - `PROJECT_BRIEF.md`
   - `docs/sprint-1/plan.md`
   - `docs/sprint-1/progress.md`
   - `docs/sprint-1/done.md`
   - `docs/sprint-1/success-paths.md`
   - `docs/qa/sprint-1-signoff.md`
4. In `plugin/orchestration.config.yaml`, set profile and role names.
5. Run next sprint using the plugin workflow (no app rewrite needed).

### Sample Example (Existing Project)

Example: you already have an ASP.NET app and want to run Sprint 1 with this plugin.

1. Copy `plugin/` into repo root.
2. Set `project.name: "Requirements Grooming"` and `profile: web-app` in `plugin/orchestration.config.yaml`.
3. Copy template docs to `PROJECT_BRIEF.md`, `docs/sprint-1/*`, and `docs/qa/sprint-1-signoff.md`.
4. Ask the workforce flow to create Sprint 1 plan using `plugin/skills/ai-team-orchestration/SKILL.md`.
5. Dev and QA run sprint execution.
6. Before merge, run `plugin/templates/validation-checklist.md`.

## Config Highlights

`plugin/orchestration.config.yaml` now includes:

- `qualityGates` for delivery governance
- `securityGuardrails` for threat model, scanning, least-privilege, and sign-off controls
- `successPaths` for measurable sprint outcomes (lead time, change failure rate, defect escape rate, coverage)
- `paths.successPaths` for `docs/sprint-N/success-paths.md`

## Security and Success Workflow

Use these artifacts every sprint:

- `plugin/skills/ai-team-orchestration/references/modules/security-guardrails.md`
- `plugin/skills/ai-team-orchestration/references/modules/success-paths.md`
- `plugin/templates/docs/sprint-N/success-paths.md`
- `plugin/templates/validation-checklist.md`

Minimum expectations:

- Do not merge with unresolved critical vulnerabilities unless an approved, time-boxed exception exists.
- Do not treat sprint success as complete without measured target vs actual outcomes.
- Do not promote to production without release reliability and security sign-off where required.

## Keep This Plugin Updated

When updating the plugin, keep these in sync:

1. Behavior docs (`plugin/skills/ai-team-orchestration/**`)
2. Config contract (`plugin/orchestration.config.yaml` and `plugin/schema/orchestration.config.schema.json`)
3. Templates (`plugin/templates/**`)
4. Agent definitions (`plugin/agents/**`)
5. Changelog (`plugin/CHANGELOG.md`)

Before publishing plugin updates:

- Validate config against schema
- Verify README instructions still match templates and skill modules
- Confirm changelog includes all newly added or changed artifacts
