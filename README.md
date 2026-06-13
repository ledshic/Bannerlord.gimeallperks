# Bannerlord Perk Concierge

Manually grants **all currently available perks** to the player hero (player-only) through an MCM action button. Useful for testing, roleplay, or quickly syncing perk state when needed.

## Features

- Adds an MCM page with an **Apply** button to grant all perks on demand.
- Respects an ignore list (`ModuleData/ignore_perks.txt`) so you can skip specific perks (e.g. "Mighty Blow").
- No automatic perk grant on campaign load.
- Lightweight implementation with MCM v5 support.
- Works on new and existing saves.

## Installation

1. Download the latest release zip.
2. Copy the `Bannerlord.GimeAllPerks` folder to `Modules/`.
3. Enable it in the Launcher.
4. Load (or start) a campaign.
5. Open MCM, find **Perk Concierge**, then click **Apply**.

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

## Dependencies & Load Order

Requires MCM v5 stack (`Harmony`, `ButterLib`, `UIExtenderEx`, `MCM`).

Place this mod after core game modules and with the MCM stack enabled.

## License

Free to use, modify, and redistribute.

## Credits

- TaleWorlds for the perk system and CampaignBehavior extensibility.
