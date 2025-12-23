# 🔒 Git Security Setup - C# SuperHero API

## Current Status

✅ `.gitignore` is configured to exclude sensitive files
✅ Configuration templates are tracked (safe)
✅ Actual configuration files are ignored (secure)

## What's Tracked in Git

### Safe Files (Committed)
- ✅ `.gitignore` - Git ignore rules
- ✅ `appsettings.example.json` - Configuration template for production
- ✅ `appsettings.Development.example.json` - Configuration template for development
- ✅ `.env.example` - Docker Compose environment template
- ✅ `SECURITY.md` - This security guide

### Ignored Files (Not Committed)
- ❌ `appsettings.json` - Production configuration with secrets
- ❌ `appsettings.Development.json` - Development configuration with secrets
- ❌ `.env` - Docker Compose environment with secrets
- ❌ `docker-compose.override.yml` - Local Docker overrides
- ❌ All `bin/` and `obj/` folders
- ❌ Visual Studio user files (`.vs/`, `*.user`, `*.suo`)

## Initial Setup

### For New Developers

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Backend/C#
   ```

2. **Copy configuration templates**
   ```bash
   # Copy appsettings templates
   cd SuperHero.API
   cp appsettings.example.json appsettings.json
   cp appsettings.Development.example.json appsettings.Development.json
   
   # Copy Docker environment template
   cd ..
   cp .env.example .env
   ```

3. **Get credentials from team lead** or generate your own for local development

4. **Edit configuration files** with actual credentials

5. **Verify files are ignored**
   ```bash
   git status
   # Should NOT show appsettings.json, appsettings.Development.json, or .env
   ```

## Verifying Git Configuration

### Check Ignored Files

```bash
# List all files tracked by git in current directory
git ls-files

# Should include:
# - appsettings.example.json ✅
# - appsettings.Development.example.json ✅
# - .env.example ✅

# Should NOT include:
# - appsettings.json ❌
# - appsettings.Development.json ❌
# - .env ❌
```

### Check What Would Be Committed

```bash
git status

# If you see these files, DO NOT COMMIT:
# - appsettings.json
# - appsettings.Development.json
# - .env
# - docker-compose.override.yml
```

## If You Accidentally Staged Secrets

### Before Committing

```bash
# Unstage the files
git reset HEAD appsettings.json
git reset HEAD appsettings.Development.json
git reset HEAD .env

# Verify .gitignore is working
git check-ignore appsettings.json
# Should output: appsettings.json (confirming it's ignored)
```

### After Committing (But Before Pushing)

```bash
# Remove from last commit
git reset --soft HEAD~1

# Remove from staging
git reset HEAD appsettings.json appsettings.Development.json .env

# Recommit without secrets
git commit -m "your message"
```

### After Pushing (URGENT!)

```bash
# 1. IMMEDIATELY rotate all exposed credentials

# 2. Remove from Git tracking
git rm --cached SuperHero.API/appsettings.json
git rm --cached SuperHero.API/appsettings.Development.json
git rm --cached .env

# 3. Commit the removal
git commit -m "security: Remove sensitive configuration files"

# 4. Push
git push

# 5. Remove from history (advanced)
# See "Removing from History" section below
```

## Removing from History

If secrets were already pushed, you must remove them from Git history:

### Using BFG Repo-Cleaner (Recommended)

```bash
# Install BFG: https://rtyley.github.io/bfg-repo-cleaner/

# Remove files from history
bfg --delete-files appsettings.json
bfg --delete-files appsettings.Development.json
bfg --delete-files .env

# Clean up
git reflog expire --expire=now --all
git gc --prune=now --aggressive

# Force push (coordinate with team!)
git push --force
```

### Using git filter-branch (Built-in)

```bash
# WARNING: This rewrites entire repository history

git filter-branch --force --index-filter \
  "git rm --cached --ignore-unmatch SuperHero.API/appsettings.json SuperHero.API/appsettings.Development.json .env" \
  --prune-empty --tag-name-filter cat -- --all

# Force push
git push origin --force --all
git push origin --force --tags
```

### After History Cleanup

1. **Notify all team members** to re-clone the repository
2. **Rotate ALL exposed credentials immediately**
3. **Monitor for unauthorized access**
4. **Document the incident**

## Adding New Configuration Files

When adding new configuration files that contain secrets:

1. **Add to `.gitignore`** BEFORE creating the file
   ```bash
   echo "newsecretfile.json" >> .gitignore
   git add .gitignore
   git commit -m "Add newsecretfile.json to gitignore"
   ```

2. **Create example template** without secrets
   ```bash
   # Create newsecretfile.example.json with placeholders
   git add newsecretfile.example.json
   git commit -m "Add newsecretfile example template"
   ```

3. **Create actual file** with secrets (will be ignored)
   ```bash
   cp newsecretfile.example.json newsecretfile.json
   # Edit with real values
   ```

## Pre-Commit Checklist

Before every commit:

- [ ] Run `git status` and review files to be committed
- [ ] Ensure no `appsettings*.json` files (except examples)
- [ ] Ensure no `.env` files (except examples)
- [ ] Ensure no `docker-compose.override.yml`
- [ ] Check for hardcoded passwords in code
- [ ] Verify .gitignore is up to date

## Visual Studio Integration

### Git Changes Window

In Visual Studio, before committing:

1. Open **Git Changes** window (View → Git Changes)
2. Review **Staged Changes** section
3. Look for:
   - ❌ `appsettings.json`
   - ❌ `appsettings.Development.json`
   - ❌ `.env`
4. If found, right-click → **Unstage**

### User Secrets

Visual Studio offers User Secrets for local development:

1. Right-click **SuperHero.API** project
2. Select **Manage User Secrets**
3. Store sensitive data in `secrets.json` (never committed)

## Team Workflow

### For Team Leads

1. **Share credentials securely**
   - Use password manager (1Password, LastPass, etc.)
   - Use secure messaging (Signal, encrypted email)
   - Never commit to Git
   - Never share in plain text chat

2. **Onboarding new developers**
   - Provide templates
   - Share credentials securely
   - Review their git status before first commit
   - Ensure they understand security practices

### For Developers

1. **Never commit secrets**
2. **Always use templates**
3. **Check git status before committing**
4. **Report any accidental exposure immediately**

## Emergency Response

If secrets are exposed:

### Immediate Actions (Within 1 hour)

1. **Assess exposure**
   - What was exposed?
   - Who has access?
   - How long was it exposed?

2. **Rotate credentials immediately**
   - MongoDB passwords
   - RabbitMQ passwords
   - JWT secrets
   - API tokens

3. **Remove from Git**
   - Use methods above
   - Force push if necessary

### Short-term Actions (Within 24 hours)

4. **Audit access logs**
   - Check for unauthorized access
   - Review recent API calls
   - Check database logs

5. **Notify stakeholders**
   - Team members
   - Security team
   - Management (if required)

### Long-term Actions

6. **Incident review**
   - Document what happened
   - How to prevent in future
   - Update procedures

7. **Improve processes**
   - Add pre-commit hooks
   - Automate secret scanning
   - Enhanced training

## Automated Checks

### Git Hooks (Optional)

Create `.git/hooks/pre-commit`:

```bash
#!/bin/sh

# Check for potential secrets
if git diff --cached --name-only | grep -E "appsettings\.json$|appsettings\.Development\.json$|^\.env$"; then
    echo "❌ ERROR: Attempting to commit sensitive configuration files!"
    echo "Files detected:"
    git diff --cached --name-only | grep -E "appsettings\.json$|appsettings\.Development\.json$|^\.env$"
    echo ""
    echo "Please unstage these files:"
    echo "  git reset HEAD <file>"
    exit 1
fi

exit 0
```

Make executable:
```bash
chmod +x .git/hooks/pre-commit
```

### Secret Scanning Tools

Consider using:
- **git-secrets**: Prevents committing secrets
- **truffleHog**: Scans history for secrets
- **detect-secrets**: Pre-commit framework
- **GitHub Secret Scanning**: Automatic detection

## FAQ

**Q: Why can't we just encrypt the files?**
A: Files change frequently, encryption adds complexity, and keys must still be managed securely. Better to keep secrets out of Git entirely.

**Q: Can I use User Secrets for production?**
A: No. User Secrets are for local development only. Production should use environment variables, Azure Key Vault, or similar.

**Q: What if I need to share configuration with team?**
A: Use example templates in Git, share actual values through secure channels (password manager, encrypted messaging).

**Q: How do I know if a file is being tracked?**
A: Run `git ls-files | grep filename` - if it appears, it's tracked.

**Q: Can I just delete the commit locally?**
A: If you haven't pushed, yes. If you've pushed, you must remove from history and notify team.

## Additional Resources

- [Git Secrets Guide](https://git-scm.com/book/en/v2/Git-Tools-Credential-Storage)
- [.NET User Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [GitHub Security Best Practices](https://docs.github.com/en/code-security/getting-started/best-practices-for-preventing-data-leaks-in-your-organization)
- [OWASP Secrets Management](https://cheatsheetseries.owasp.org/cheatsheets/Secrets_Management_Cheat_Sheet.html)

---

**Remember**: When in doubt, ask before committing. Prevention is easier than remediation! 🔒
