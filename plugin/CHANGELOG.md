# Changelog

All notable changes to this plugin are documented in this file.

## 1.2.1 - 2026-07-17

- Added dedicated DevOps agent: `plugin/agents/ai-team-devops.agent.md`.
- Updated `plugin/README.md` agent catalog to include DevOps execution role.

## 1.2.0 - 2026-07-17

- Added three specialized agents in `plugin/agents/`:
	- `ai-team-security-gatekeeper.agent.md`
	- `ai-team-release-reliability.agent.md`
	- `ai-team-delivery-intelligence.agent.md`
- Updated `plugin/README.md` with a dedicated section describing these agents and intended usage.

## 1.1.0 - 2026-07-17

- Added required `securityGuardrails` contract block in `plugin/orchestration.config.yaml` and schema.
- Added required `successPaths` contract block with measurable delivery targets.
- Added new path contract key for `docs/sprint-N/success-paths.md`.
- Added sprint success-path template at `plugin/templates/docs/sprint-N/success-paths.md`.
- Added `security-guardrails.md` and `success-paths.md` modules to orchestration references.
- Expanded validation checklist with mandatory security and success checks.
- Updated onboarding docs and skill entrypoint to include secure guardrails and success path workflow.

## 1.0.0 - 2026-07-10

- Introduced config-first plugin contract in `plugin/orchestration.config.yaml`.
- Added schema in `plugin/schema/orchestration.config.schema.json`.
- Added reusable team profiles in `plugin/profiles/`.
- Added modular orchestration references in `plugin/skills/ai-team-orchestration/references/modules/`.
- Added reusable bootstrap templates in `plugin/templates/`.
- Added onboarding guidance and validation checklist.
