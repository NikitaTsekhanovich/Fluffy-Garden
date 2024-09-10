using System.Collections.Generic;
using Store.Items.Properties;
using UnityEngine;

namespace Store.Items
{
    public class StoreHelper<T> : IStore 
        where T : IStore, IItem
    {
        private List<T> _currentData = new ();

        public StoreHelper(List<T> data)
        {
            _currentData = new List<T>(data);
        }

        public Sprite GetIcon(int index) => _currentData[index].Sprite;

        public bool GetIsChosen(int index) => _currentData[index].IsChosen;

        public bool GetIsOpen(int index) => _currentData[index].IsOpen;

        public int GetPrice(int index) => _currentData[index].Price;

        public int GetCountData() => _currentData.Count;

        public void SetIsOpen(int index, bool value)
        {
            _currentData[index].IsOpen = value;
        }

        public void SetIsChosen(int index, bool value)
        {
            _currentData[index].IsChosen = value;
        }
    }
}
