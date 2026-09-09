# AI Team Orchestration Workspace

Final plugin package now lives in `plugin/`.

See full plugin guide: `plugin/README.md`

## Onboard a New Project (Simple)

1. Copy the `plugin/` folder into your new project repository.
2. Edit `plugin/orchestration.config.yaml` and choose a profile (`web-app`, `api-only`, `data-app`).
3. Create project docs from templates:
	- `plugin/templates/PROJECT_BRIEF.md` -> `PROJECT_BRIEF.md`
	- `plugin/templates/docs/sprint-N/plan.md` -> `docs/sprint-1/plan.md`
	- `plugin/templates/docs/sprint-N/progress.md` -> `docs/sprint-1/progress.md`
	- `plugin/templates/docs/sprint-N/done.md` -> `docs/sprint-1/done.md`
	- `plugin/templates/docs/qa/sprint-N-signoff.md` -> `docs/qa/sprint-1-signoff.md`
4. Use `plugin/skills/ai-team-orchestration/SKILL.md` to run planning and execution.
5. Run `plugin/templates/validation-checklist.md` before each merge.
