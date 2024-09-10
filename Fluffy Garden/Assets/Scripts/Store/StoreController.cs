using PlayerControllers;
using Store.Items;
using Store.Items.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Store
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countCoins;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _iconCharacter;
        [SerializeField] private GameObject _nextButton;
        [SerializeField] private GameObject _prevButton;

        private int _index;
        private IStore _store;

        public void ChooseCharacterStore()
        {
            
            _store = new StoreHelper<CharacterData>(SkinsData.CharactersData);
            
            SetCurrentData(_store);
        }

        public void ChooseBackgroundStore()
        {
            _store = new StoreHelper<BackgroundsData>(SkinsData.BackgroundsData);

            SetCurrentData(_store);
        }

        private void SetCurrentData(IStore store)
        {
            _countCoins.text = $"{PlayerDataController.Coins}";
            _iconCharacter.sprite = store.GetIcon(_index);
            CheckPrice();
        }

        public void BuyCharacter()
        {
            if (PlayerDataController.CanBuyItem(_store.GetPrice(_index)) && 
                !_store.GetIsOpen(_index))
            {
                PlayerDataController.ChangeCountCoin(-_store.GetPrice(_index));
                _store.SetIsOpen(_index, true);
                _countCoins.text = $"{PlayerDataController.Coins}";
                CheckPrice();
            }

            if (_store.GetIsOpen(_index))
            {
                for(var i = 0; i < _store.GetCountData(); i++)
                    _store.SetIsChosen(i, false);

                _store.SetIsChosen(_index, true);
                CheckPrice();
            }
        }

        public void SwitchNextCharacter()
        {
            if (_index < _store.GetCountData() - 1)
            {
                _index++;
                _prevButton.SetActive(true);

                if (_index >= _store.GetCountData() - 1)
                    _nextButton.SetActive(false);
            }

            SwitchCharacter();
        }

        public void SwitchPreviousCharacter()
        {
            if (_index > 0)
            {
                _index--;
                _nextButton.SetActive(true);

                if (_index <= 0)
                    _prevButton.SetActive(false);
            }              

            SwitchCharacter();
        }

        private void SwitchCharacter()
        {
            _iconCharacter.sprite = _store.GetIcon(_index);
            CheckPrice();
        }

        private void CheckPrice()
        {
            if (_store.GetIsOpen(_index) && !_store.GetIsChosen(_index))
                _price.text = "Open";
            else
                _price.text = $"{_store.GetPrice(_index)}";

            if (_store.GetIsOpen(_index) && _store.GetIsChosen(_index))
                _price.text = "Selected";
        }
    }
}

