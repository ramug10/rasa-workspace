# Core Workflow

This module defines the baseline orchestration lifecycle.

## Stage 1: Initialize

1. Load `orchestration.config.yaml` and selected `profiles/<name>.yaml`.
2. Create `PROJECT_BRIEF.md` from `templates/PROJECT_BRIEF.md`.
3. Create sprint docs from `templates/docs/sprint-N/`.
4. Confirm branch naming and labels align with config.

## Stage 2: Plan

1. Run brainstorm using `references/brainstorm-format.md`.
2. Convert outcomes into a sprint plan with explicit quality gates.
3. Capture out-of-scope items before development starts.

## Stage 3: Execute

1. Development team implements scoped tasks on feature branch.
2. Progress tracker is updated after each phase.
3. Producer monitors scope, issue status, and risks.

## Stage 4: Verify

1. QA validates manually and through automation.
2. Bugs are filed as GitHub Issues with severity labels.
3. Fixes are verified by QA before closure.

## Stage 5: Close

1. Write done file, update project brief state sections.
2. Ensure QA sign-off status is explicit.
3. Merge using regular merge strategy only.
