using System.Collections.Generic;
using TaleWorlds.CampaignSystem;

namespace Indoctrinator
{
    public interface IIndoctrinator
    {
        void Indoctrinate(IEnumerable<Settlement> settlements);
        void LoadData(Dictionary<string, int> data);
        Dictionary<string, int> SaveData();
    }
}
