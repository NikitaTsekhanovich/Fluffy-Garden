using System.Collections.Generic;
using Store.Items;
using UnityEngine;
using System.Linq;
using Store.Items.Properties;

namespace Store
{
    public class SkinsData : MonoBehaviour
    {
        [field: SerializeField] public static List<CharacterData> CharactersData { get; private set; }
        [field: SerializeField] public static List<BackgroundsData> BackgroundsData { get; private set; }

        private void Start()
        {
            LoadCurrentCharactersData();
            LoadCurrentBackgroundsData();
        }

        private static void LoadCurrentCharactersData()
        {
            CharactersData = Resources.LoadAll<CharacterData>("ScriptableObjectData/CharactersData")
                .OrderBy(x => x.Price)
                .ToList();
        }

        private static void LoadCurrentBackgroundsData()
        {
            BackgroundsData = Resources.LoadAll<BackgroundsData>("ScriptableObjectData/BackgroundsData")
                .OrderBy(x => x.Price)
                .ToList();;
        }

        public static CharacterData GetCurrentCharacter()
        {
            LoadCurrentCharactersData();
            return GetCurrentData(CharactersData);
        }

        public static BackgroundsData GetCurrentBackground()
        {
            LoadCurrentBackgroundsData();
            return GetCurrentData(BackgroundsData);
        }

        public static TData GetCurrentData<TData>(List<TData> itemsData)
            where TData : ItemData
        {
            foreach (var itemData in itemsData)
            {
                if (itemData.IsChosen)
                    return itemData;
            }
            return null;
        }
    }
}

