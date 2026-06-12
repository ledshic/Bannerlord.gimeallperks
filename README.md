# Bannerlord.GimeAllPerks

Grants **all currently available perks** to the player hero (player-only) as soon as a campaign session is loaded. Perfect for testing, roleplay, or just having fun with every perk.

## Features

- Automatically unlocks every perk the player does not yet have after loading a campaign.
- Respects an ignore list (`ModuleData/ignore_perks.txt`) so you can skip specific perks (e.g. "Mighty Blow").
- Simple, lightweight, no Harmony or MCM dependency.
- Works on new and existing saves.

## Installation

1. Download the latest release zip.
2. Copy the `Bannerlord.GimeAllPerks` folder to `Modules/`.
3. Enable it in the Launcher.
4. Load (or start) a campaign. All perks will be granted shortly after the session begins.

You will see chat messages indicating how many perks were added and which (if any) were ignored.

## Configuration

Edit `ModuleData/ignore_perks.txt` inside the installed module folder (or in `dev/module/ModuleData/` in the repo).

- One entry per line.
- Entries can be perk string IDs (e.g. `OneHandedExpert`) **or** exact perk display names.
- Lines starting with `#` are comments.
- Changes require a game restart / module reload to take effect.

Default ignores "Mighty Blow" (and its Chinese name).

## Localization (l10n)

All feedback messages are localized using Bannerlord's standard system.

- Base English provided.
- Community contributions for other languages (CN, etc.) are welcome via `ModuleData/Languages/<culture>/`.

## Building from Source

Unified layout (same as other mods in the collection):

```powershell
./dev/build.ps1 -Version v0.2.0
```

Outputs:

- `out/Bannerlord.GimeAllPerks/`
- `out/Bannerlord.GimeAllPerks-v0.2.0.zip`

Uses `Bannerlord.ReferenceAssemblies` (no local game install required for compilation).

## Load Order

Can be placed anywhere after the core game modules. No dependencies on Harmony/MCM/BUTTER stack.

## License

Free to use, modify, and redistribute.

## Credits

- TaleWorlds for the perk system and CampaignBehavior extensibility.
