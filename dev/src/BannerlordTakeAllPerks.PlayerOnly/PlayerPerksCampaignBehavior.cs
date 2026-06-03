using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace BannerlordTakeAllPerks.PlayerOnly;

public sealed class PlayerPerksCampaignBehavior : CampaignBehaviorBase
{
    private bool _applied;

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
        foreach (PerkObject perk in PerkObject.All)
        {
            if (mainHero.GetPerkValue(perk))
            {
                continue;
            }

            if (mainHero.GetSkillValue(perk.Skill) < perk.RequiredSkillValue)
            {
                continue;
            }

            mainHero.HeroDeveloper.AddPerk(perk);
            addedCount++;
        }

        InformationManager.DisplayMessage(new InformationMessage($"Take All Perks: added {addedCount} perks to player."));
    }
}
