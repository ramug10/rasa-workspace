---
name: ai-team-orchestration
description: 'Bootstrap and run a multi-agent AI development team. Use when: starting a new software project with AI agents, setting up parallel dev/QA teams, creating sprint plans, writing brainstorm prompts with distinct agent voices, recovering a project workflow, or planning sprints.'
---

# AI Team Orchestration

## Version

- `orchestrationVersion`: `1.0.0`
- Contract source: `orchestration.config.yaml`
- Contract schema: `schema/orchestration.config.schema.json`

## Purpose

Use this skill to run a reusable, role-based delivery workflow across teams while keeping team-specific settings in configuration.

## Required Inputs

Before running orchestration, ensure these exist:

- `orchestration.config.yaml`
- One active profile from `profiles/`
- `PROJECT_BRIEF.md` generated from template
- Sprint docs generated from templates

## Module Index

- Core lifecycle: `references/modules/core-workflow.md`
- Role boundaries: `references/modules/role-contracts.md`
- Handoff rules: `references/modules/handoff-protocol.md`
- Quality gates: `references/modules/quality-gates.md`
- Brainstorm format: `references/brainstorm-format.md`
- Sprint templates: `references/sprint-plan-template.md`
- Anti-patterns: `references/anti-patterns.md`

## Project Bootstrap

### 1. Load Configuration

Read `orchestration.config.yaml` and apply values for:

- Role names
- Branch prefixes
- Labels
- Quality gates
- Sprint cadence

### 2. Initialize Artifacts

Create project artifacts from templates:

- `templates/PROJECT_BRIEF.md`
- `templates/docs/sprint-N/plan.md`
- `templates/docs/sprint-N/progress.md`
- `templates/docs/sprint-N/done.md`
- `templates/docs/qa/sprint-N-signoff.md`

### 3. Plan and Execute

Run brainstorm, plan sprint, execute in role-specific chats, and enforce quality gates before merge.

### 4. Validate Before Merge

Use `templates/validation-checklist.md` to verify governance completeness.

## Core Principles

- Config-driven customization, not prompt rewrites
- Strict role boundaries by file and action
- Persistent handoff files as shared memory
- Regular merge strategy only
- QA verification required for blocker resolution

## Notes

Role names in examples are defaults and should be overridden in `orchestration.config.yaml`.