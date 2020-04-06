using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Indoctrinator
{
    public class Main : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            var campaign = game.GameType as Campaign;

            if (campaign == null)
            {
                return;
            }

            AddBehaviours(gameStarterObject as CampaignGameStarter);
        }

        private void AddBehaviours(CampaignGameStarter campaignGameStarter)
        {
            campaignGameStarter.AddBehavior(new IndoctrinationModule());
        }
    }
}
