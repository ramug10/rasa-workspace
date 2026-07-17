# Success Paths

Success paths define measurable outcomes that confirm the team is shipping safely and predictably.

## Required Sprint Targets

- Lead time from first commit to merge is at or below target days.
- Change failure rate remains at or below target percentage.
- Defect escape rate remains at or below target percentage.
- Automated test coverage remains at or above minimum target.
- Runbook exists for all critical user and operational flows.
- Post-release verification is completed and recorded.

## How to Use

- Initialize sprint targets from `orchestration.config.yaml`.
- Track outcomes in `docs/sprint-N/success-paths.md`.
- Review deltas in sprint retrospective and update targets intentionally.

## Healthy Signal

A sprint is considered healthy when all required targets meet threshold and no blocking security exceptions are active.
