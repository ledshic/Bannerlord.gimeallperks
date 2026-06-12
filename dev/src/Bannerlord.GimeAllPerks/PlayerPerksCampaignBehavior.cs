using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace Bannerlord.GimeAllPerks;

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

        var addedMsg = new TextObject("{=GIME_ADDED}Gime All Perks: added {ADDED} perks to player. Ignored {IGNORED} perk(s).");
        addedMsg.SetTextVariable("ADDED", addedCount);
        addedMsg.SetTextVariable("IGNORED", ignoredCount);
        InformationManager.DisplayMessage(new InformationMessage(addedMsg.ToString()));

        if (resolvedIgnored.Count > 0)
        {
            string ignoredText = string.Join(", ", resolvedIgnored.Distinct());
            var ignoredMsg = new TextObject("{=GIME_IGNORED}Ignored perks: {LIST}");
            ignoredMsg.SetTextVariable("LIST", ignoredText);
            InformationManager.DisplayMessage(new InformationMessage(ignoredMsg.ToString()));
        }
    }
}
