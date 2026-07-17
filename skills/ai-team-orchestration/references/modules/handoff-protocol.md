# Handoff Protocol

Handoffs are mandatory and are the only durable memory across chats.

## Required outputs per sprint

1. `docs/sprint-N/progress.md` updated with final phase status.
2. `docs/sprint-N/done.md` completed with build summary and remaining work.
3. `PROJECT_BRIEF.md` sections for sprint status and current state rewritten.

## Required bug tracking

1. Every bug must exist as a GitHub Issue.
2. Severity labels must be applied (`severity:blocker`, `severity:major`, `severity:minor`).
3. Closed issue requires QA verification evidence.

## Cold start prompt

"Read PROJECT_BRIEF.md and docs/sprint-N/progress.md. Continue from the latest completed task and open blockers."
