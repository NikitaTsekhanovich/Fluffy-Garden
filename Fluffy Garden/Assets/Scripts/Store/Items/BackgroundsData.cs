using Store.Items.Properties;
using UnityEngine;

namespace Store.Items
{
    [CreateAssetMenu(fileName = "BackgroundsData", menuName = "Items data/ Background")]
    public class BackgroundsData : ItemData
    {
        [SerializeField] private Sprite _joystickSprite;
        [SerializeField] private Sprite _transparentBackgroundSprite;
        [SerializeField] private Sprite _itemSprite;
        [SerializeField] private Sprite _timeBarSprite;

        public Sprite JoystickSprite => _joystickSprite;
        public Sprite TransparentBackgroundSprite => _transparentBackgroundSprite;
        public Sprite ItemSprite => _itemSprite;
        public Sprite TimeBarSprite => _timeBarSprite;
    }
}

