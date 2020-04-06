using TaleWorlds.CampaignSystem;

namespace Indoctrinator
{
    public interface ITroopFinder
    {
        TroopRoster GetGarrison(Settlement settlement);
        TroopRoster GetPrisoners(Settlement settlement);
    }
}
