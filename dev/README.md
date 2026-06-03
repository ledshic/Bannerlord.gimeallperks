# Bannerlord Take All Perks (Player Only)

This development folder contains a standalone implementation that grants all currently available perks to the player hero after a campaign session is loaded.

## Local build and package

Run from repository root:

```powershell
./dev/build.ps1 -Version v0.1.0
```

Outputs:

- `out/BannerlordTakeAllPerksPlayerOnly/` (ready-to-copy module folder)
- `out/BannerlordTakeAllPerksPlayerOnly-v0.1.0.zip` (release package)

## GitHub Actions release

Use `Build And Release Mod` workflow with `workflow_dispatch`:

1. Set `version` (for tag and module `SubModule.xml` version).
2. Choose `prerelease` true/false.
3. Run workflow.

The workflow compiles, assembles the Bannerlord module structure, uploads artifact, and publishes GitHub release.
