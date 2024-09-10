using Store.Items.Properties;
using UnityEngine;

namespace Store.Items
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Items data/ Character")]
    public class CharacterData : ItemData
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}

