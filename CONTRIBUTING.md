# Contributing Guidelines

This document defines the workflow, branch naming, commit conventions, and PR process for this repository.  
The goal is to keep the project history clean, professional, and easy to follow.

---

## Branch Strategy

- **main**  
  - Production-ready branch.  
  - Always stable and deployable.  
  - Only updated via pull requests (PR) from `dev`.

- **dev**  
  - Integration branch where all features, fixes, and chores are merged.  
  - Updated via PRs only.

- **feature branches**  
  - For new features.  
  - Naming: `feature/<short-description>`  
  - Example: `feature/authentication`, `feature/ticket-crud`.

- **fix branches**  
  - For bug fixes.  
  - Naming: `fix/<short-description>`  
  - Example: `fix/login-redirect`, `fix/db-connection`.

- **chore branches**  
  - For maintenance, tools, or configuration changes.  
  - Naming: `chore/<short-description>`  
  - Example: `chore/update-gitignore`, `chore/setup-ci`.

- **docs branches**  
  - For documentation updates.  
  - Naming: `docs/<short-description>`  
  - Example: `docs/add-readme`, `docs/architecture-update`.

- **hotfix branches**  
  - For urgent fixes applied directly to `main`.  
  - Naming: `hotfix/<short-description>`  
  - Example: `hotfix/fix-production-bug`.

👉 Branches are **short-lived** and deleted after merge.

---

## Commit Convention

I follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

`<type>(<scope>): <message>`

Types:
- `feat` → new feature  
- `fix` → bug fix  
- `chore` → maintenance/configuration  
- `docs` → documentation only  
- `refactor` → code refactor without changing functionality  
- `test` → adding or modifying tests  

Examples:
- `feat(auth): add JWT authentication`
- `fix(api): resolve null reference bug`
- `chore(gitignore): exclude .env`
- `docs(readme): update installation steps`

---

## Pull Requests

- All changes go through a Pull Request (PR).  
- PRs target the `dev` branch (except hotfixes).  
- Each PR should be linked to an issue in GitHub Projects (if relevant).  
- PR titles should follow commit conventions (e.g., `feat(auth): implement login endpoint`).  
- Squash merge is recommended to keep a clean history.  

---

## Code Style & Standards

- Code follows language-specific best practices.  
- Linting and formatting tools applied before committing.  
- Sensitive information (e.g., API keys, `.env` files, certificates) **never** committed.  

---

## Workflow Summary

1. Create a branch from `dev`:
```bash
    git checkout dev
    git pull
    git checkout -b feature/my-feature
```
2. Make changes and commit with proper convention:
```bash
    git commit -m "feat(api): add new ticket endpoint"
```
3. Push and open a PR to dev:
```bash
    git push origin feature/my-feature
```
4. Get the PR reviewed (self-review).

5. Merge via squash merge, then delete the branch.

## Security Guidelines

- Never commit .env, secrets, API keys, or credentials.
- Use .gitignore to exclude environment/config files.
- Keep dependencies updated to reduce vulnerabilities.