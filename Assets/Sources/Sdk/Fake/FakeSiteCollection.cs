
using System.Collections.Generic;

namespace Basketball_YG.Sdk
{
    public class FakeSiteCollection : ICollectionSkinsSender, ICollectionSkinsProvider
    {
        private readonly HashSet<int> _ids = new();

        public void AddId(int id)
        {
            _ids.Add(id);
        }

        public bool HasId(int id)
        {
            return _ids.Contains(id);
        }
    }
}