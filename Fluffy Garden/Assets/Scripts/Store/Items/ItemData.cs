using UnityEngine;

namespace Store.Items.Properties
{
    public class ItemData : ScriptableObject, IItem, IStore
    {
        [SerializeField] private int _price;
        [SerializeField] private bool _isOpen;
        [SerializeField] private bool _isChosen;
        [SerializeField] private Sprite _sprite;

        public int Price => _price;
        public bool IsOpen { get => _isOpen; set { _isOpen = value; } }
        public bool IsChosen { get => _isChosen; set { _isChosen = value; } }
        public Sprite Sprite => _sprite;

        public int GetCountData()
        {
            throw new System.NotImplementedException();
        }

        public Sprite GetIcon(int index)
        {
            throw new System.NotImplementedException();
        }

        public bool GetIsChosen(int index)
        {
            throw new System.NotImplementedException();
        }

        public bool GetIsOpen(int index)
        {
            throw new System.NotImplementedException();
        }

        public int GetPrice(int index)
        {
            throw new System.NotImplementedException();
        }

        public void SetIsChosen(int index, bool value)
        {
            throw new System.NotImplementedException();
        }

        public void SetIsOpen(int index, bool value)
        {
            throw new System.NotImplementedException();
        }
    }
}

