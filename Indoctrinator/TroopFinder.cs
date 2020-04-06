using TaleWorlds.CampaignSystem;

namespace Indoctrinator
{
    public class TroopFinder : ITroopFinder
    {
        public TroopRoster GetGarrison(Settlement settlement)
        {
            if (settlement.Town.GarrisonParty == null)
            {
                settlement.Town.GarrisonParty = MobileParty.Create($"Garrison of {settlement.Name}");
            }

            return settlement.Town.GarrisonParty.MemberRoster;
        }

        public TroopRoster GetPrisoners(Settlement settlement)
        {
            return settlement.Party.PrisonRoster;
        }
    }
}