using UnityEngine;

namespace Store.Items.Properties
{
    public interface IStore
    {
        public Sprite GetIcon(int index);
        public int GetPrice(int index);
        public bool GetIsOpen(int index);
        public bool GetIsChosen(int index);
        public int GetCountData();
        public void SetIsOpen(int index, bool value);
        public void SetIsChosen(int index, bool value);
    }
}

