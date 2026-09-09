# Anti-Patterns

| Do Not | Do Instead | Why |
|---|---|---|
| Rebase shared feature branches | Use regular merge | Preserves team history and easier rollback |
| Keep bugs only in chat | File GitHub Issues | Durable cross-chat source of truth |
| Let producer write app code | Keep producer in coordination role | Preserves governance and scope control |
| Skip handoff docs | Maintain progress and done docs every sprint | Enables clean context recovery |
| Merge before QA | Require QA sign-off first | Prevents broken main branch |
