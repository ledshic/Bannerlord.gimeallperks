using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace BannerlordTakeAllPerks.PlayerOnly;

public sealed class PlayerPerksCampaignBehavior : CampaignBehaviorBase
{
    private bool _applied;
    private readonly HashSet<string> _ignoreEntries;

    public PlayerPerksCampaignBehavior(HashSet<string> ignoreEntries)
    {
        _ignoreEntries = ignoreEntries;
    }

    public override void RegisterEvents()
    {
        CampaignEvents.OnAfterSessionLaunchedEvent.AddNonSerializedListener(this, OnAfterSessionLaunched);
    }

    public override void SyncData(IDataStore dataStore)
    {
    }

    private void OnAfterSessionLaunched(CampaignGameStarter starter)
    {
        if (_applied)
        {
            return;
        }

        _applied = true;
        Hero? mainHero = Hero.MainHero;
        if (mainHero == null || mainHero.HeroDeveloper == null)
        {
            return;
        }

        int addedCount = 0;
        int ignoredCount = 0;
        List<string> resolvedIgnored = new();
        foreach (PerkObject perk in PerkObject.All)
        {
            if (PerkIgnoreConfig.IsIgnored(perk, _ignoreEntries))
            {
                ignoredCount++;
                resolvedIgnored.Add(PerkIgnoreConfig.FormatPerk(perk));
                continue;
            }

            if (mainHero.GetPerkValue(perk))
            {
                continue;
            }

            mainHero.HeroDeveloper.AddPerk(perk);
            addedCount++;
        }

        InformationManager.DisplayMessage(new InformationMessage($"Take All Perks: added {addedCount} perks to player. Ignored {ignoredCount} perk(s)."));

        if (resolvedIgnored.Count > 0)
        {
            string ignoredText = string.Join(", ", resolvedIgnored.Distinct());
            InformationManager.DisplayMessage(new InformationMessage($"Ignored perks: {ignoredText}"));
        }
    }
}
