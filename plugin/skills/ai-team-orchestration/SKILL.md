---
name: ai-team-orchestration
description: 'Bootstrap and run a multi-agent AI development team. Use when: starting a new software project with AI agents, setting up parallel dev/QA teams, creating sprint plans, writing brainstorm prompts with distinct agent voices, recovering a project workflow, or planning sprints.'
---

# AI Team Orchestration

## Version

- `orchestrationVersion`: `1.1.0`
- Contract source: `plugin/orchestration.config.yaml`
- Contract schema: `plugin/schema/orchestration.config.schema.json`

## Purpose

Use this skill to run a reusable, role-based delivery workflow across teams while keeping team-specific settings in configuration.

## Required Inputs

Before running orchestration, ensure these exist:

- `plugin/orchestration.config.yaml`
- One active profile from `plugin/profiles/`
- `PROJECT_BRIEF.md` generated from template
- Sprint docs generated from templates

## Module Index

- Core lifecycle: `references/modules/core-workflow.md`
- Role boundaries: `references/modules/role-contracts.md`
- Handoff rules: `references/modules/handoff-protocol.md`
- Quality gates: `references/modules/quality-gates.md`
- Security guardrails: `references/modules/security-guardrails.md`
- Success paths: `references/modules/success-paths.md`
- Brainstorm format: `references/brainstorm-format.md`
- Sprint templates: `references/sprint-plan-template.md`
- Anti-patterns: `references/anti-patterns.md`

## Project Bootstrap

### 1. Load Configuration

Read `plugin/orchestration.config.yaml` and apply values for:

- Role names
- Branch prefixes
- Labels
- Quality gates
- Sprint cadence

### 2. Initialize Artifacts

Create project artifacts from templates:

- `plugin/templates/PROJECT_BRIEF.md`
- `plugin/templates/docs/sprint-N/plan.md`
- `plugin/templates/docs/sprint-N/progress.md`
- `plugin/templates/docs/sprint-N/done.md`
- `plugin/templates/docs/sprint-N/success-paths.md`
- `plugin/templates/docs/qa/sprint-N-signoff.md`

### 3. Plan and Execute

Run brainstorm, plan sprint, execute in role-specific chats, and enforce quality gates before merge.

### 4. Validate Security and Success

Enforce security guardrails and track success paths for the sprint.

### 5. Validate Before Merge

Use `plugin/templates/validation-checklist.md` to verify governance completeness.

## Specialized Agent Invocation Guide

Use these agents at fixed points in the lifecycle to keep delivery safe and predictable.

### Sprint Start

- Invoke `ai-team-delivery-intelligence` to baseline previous sprint outcomes and set realistic targets in `docs/sprint-N/success-paths.md`.
- Invoke `ai-team-release-reliability` to define rollout and rollback expectations early for critical scope.

### During Sprint (High-Risk Changes)

- Invoke `ai-team-security-gatekeeper` when changes affect auth, data boundaries, identity/permissions, or external integrations.
- Ensure threat-model updates and scan evidence are captured before implementation is considered complete.

### Pre-Merge Gate

- Invoke `ai-team-security-gatekeeper` for final security decision (PASS/BLOCKED).
- Invoke `ai-team-delivery-intelligence` to check target-vs-actual drift and flag risk to sprint commitments.
- Merge only when required security and success checks are satisfied.

### Release Cut and Production Verification

- Invoke `ai-team-release-reliability` for GO/NO-GO decision, rollback readiness, and post-release verification.
- Re-invoke `ai-team-security-gatekeeper` before production promotion when security sign-off is required.

### Sprint Close

- Invoke `ai-team-delivery-intelligence` to produce sprint health summary, top risks, and top corrective actions for the next sprint.
