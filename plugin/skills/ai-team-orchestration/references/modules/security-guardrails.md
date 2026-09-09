# Security Guardrails

These guardrails are mandatory before merging to a protected branch.

## Required Controls

- Threat model documented for high-risk changes (auth, data exposure, privilege boundaries, external integrations).
- Secret scanning enabled in CI and local pre-push checks.
- Dependency vulnerability scan executed for application and infrastructure dependencies.
- Static analysis executed for critical code paths.
- Least-privilege review completed for service identities, tokens, and deployment permissions.
- Security sign-off captured before production deployment.

## Merge Blocking Rules

Block merge when any of the following is true:

- Critical vulnerabilities remain open without an approved exception.
- Secrets are detected in tracked files or commit history.
- Threat model is required but missing for the current change set.
- Security sign-off is required but not recorded.

## Exception Process

- Exceptions require a linked issue with owner, risk statement, compensating controls, and expiration date.
- Exceptions are time-boxed and must be re-approved at expiry.
