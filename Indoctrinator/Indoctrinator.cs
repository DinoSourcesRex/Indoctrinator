using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace Indoctrinator
{
    public class Indoctrinator : IIndoctrinator
    {
        private Dictionary<string, int> _indoctrinationScore = new Dictionary<string, int>();

        private readonly ITroopFinder _troopFinder = new TroopFinder();

        public void Indoctrinate(IEnumerable<Settlement> settlements)
        {
            var townsOrCastles = settlements.Where(s => !s.IsVillage);

            foreach (var settlement in townsOrCastles)
            {
                if (settlement.IsRebelling)
                {
                    // todo: if rebelling reducer conversion score
                }
                else
                {
                    Indoctrinate(settlement);
                }
            }

            InformationManager.DisplayMessage(new InformationMessage
            {
                Information = "Completed Indoctrination",
                Color = new Color(0.5f, 0.5f, 0.5f)
            });
        }

        public void LoadData(Dictionary<string, int> data)
        {
            _indoctrinationScore = data;
        }

        public Dictionary<string, int> SaveData()
        {
            return _indoctrinationScore;
        }

        private void Indoctrinate(Settlement settlement)
        {
            var garrisonTroops = _troopFinder.GetGarrison(settlement);
            var prisonTroops = _troopFinder.GetPrisoners(settlement);

            if (prisonTroops.TotalRegulars > 0)
            {
                garrisonTroops.Add(prisonTroops);
                prisonTroops.Clear();
            }

            /**
             * 1) calculate "influence" and add it to the existing influence
             * 2) figure out which troops you will indoctrinate and how much influence it will cost
             * 3) calculate your leftover influence and save it
             * 4) add the troops to the garrison - this requires a cap based on maximum garrison size (take best troops)
             * 5) remove troops that were added to the garrison from the prison troops
             */

            // todo: let the user select a mode - recruit the best or worst?
            // todo: let the user select if influence builds when garrison capacity is reached?
            // todo: how will the user do this? Speak to an NPC? 

            // todo: see if it is possible to enable this once a building is built
            // todo: figure out how to amass influence. Building level + some kind of player / governor influence?
        }

        private void ReeducatePrisoners(MobileParty garrisonParty)
        {
            InformationManager.DisplayMessage(new InformationMessage
            {
                Information = $"Reeducating {garrisonParty.PrisonRoster.Count}",
                Color = new Color(0.5f, 0.5f, 0.5f)
            });

            garrisonParty.MemberRoster.Add(garrisonParty.PrisonRoster);
        }
    }
}