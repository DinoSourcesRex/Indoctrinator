using System.Collections.Generic;
using TaleWorlds.CampaignSystem;

namespace Indoctrinator
{
    public class IndoctrinationModule : CampaignBehaviorBase
    {
        private readonly string _saveKey = "Indoctrinator.SaveKey";

        private readonly IIndoctrinator _indoctrinator = new Indoctrinator();

        public override void RegisterEvents()
        {
            CampaignEvents.HourlyTickEvent.AddNonSerializedListener(this, DailyTick);
            //CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
        }

        private void DailyTick()
        {
            _indoctrinator.Indoctrinate(Clan.PlayerClan.Settlements);
        }

        public override void SyncData(IDataStore dataStore)
        {
            if (dataStore.IsLoading)
            {
                var data = new Dictionary<string, int>();

                dataStore.SyncData(_saveKey, ref data);

                _indoctrinator.LoadData(data);
            }
            else if (dataStore.IsSaving)
            {
                var data = _indoctrinator.SaveData();

                dataStore.SyncData(_saveKey, ref data);
            }
        }
    }
}
