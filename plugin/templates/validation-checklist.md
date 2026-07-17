# Validation Checklist

Use this checklist before creating or merging sprint work.

## Required governance artifacts

- [ ] `plugin/orchestration.config.yaml` exists.
- [ ] Config validates against `plugin/schema/orchestration.config.schema.json`.
- [ ] `PROJECT_BRIEF.md` includes all 14 required sections.
- [ ] Sprint plan includes definition of done, risk register, test matrix, and rollback strategy.
- [ ] Sprint progress and done files are present.
- [ ] Sprint success paths file is present (`docs/sprint-N/success-paths.md`).
- [ ] QA sign-off exists and blocker status is explicit.

## Required process checks

- [ ] Work occurred in feature branches.
- [ ] Bugs are tracked as issues, not only chat notes.
- [ ] Merge strategy is regular merge, not squash/rebase.

## Required security checks

- [ ] Threat model exists for high-risk changes.
- [ ] Secret scan passes.
- [ ] Dependency vulnerability scan passes.
- [ ] Static analysis passes for changed components.
- [ ] No unresolved critical vulnerabilities (or approved, non-expired exception).
- [ ] Least-privilege review completed for identity and deployment changes.
- [ ] Security sign-off recorded before production deployment.

## Required success checks

- [ ] Lead time is measured and within target threshold.
- [ ] Change failure rate is measured and within target threshold.
- [ ] Defect escape rate is measured and within target threshold.
- [ ] Automated test coverage meets minimum threshold.
- [ ] Critical flow runbook links are documented.
- [ ] Post-release verification result is recorded.
