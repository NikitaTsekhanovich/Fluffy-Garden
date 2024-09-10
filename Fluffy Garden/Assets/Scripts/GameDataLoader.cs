using PlayerControllers;
using Store.Items;
using UnityEngine;
using UnityEngine.UI;

public class GameDataLoader : MonoBehaviour
{
    [Header ("Player skins")]
    [SerializeField] private GameObject _player;

    [Header ("UI skins")]
    [SerializeField] private Image _mainBackground;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _transparentBackground;
    [SerializeField] private GameObject _item;
    [SerializeField] private Image _timeBar;

    private static CharacterData _characterData;

    public void SetGameData(CharacterData characterData, BackgroundsData backgroundData)
    {
        ChangeSkinPlayer(characterData);
        ChangeUI(backgroundData);
    }

    private void ChangeSkinPlayer(CharacterData characterData)
    {
        _characterData = characterData;
        _player.GetComponent<SpriteRenderer>().sprite = characterData.Sprite;
    }

    private void ChangeUI(BackgroundsData backgroundData)
    {
        _mainBackground.sprite = backgroundData.Sprite;
        _joystick.sprite = backgroundData.JoystickSprite;
        _transparentBackground.sprite = backgroundData.TransparentBackgroundSprite;
        _item.GetComponent<SpriteRenderer>().sprite = backgroundData.ItemSprite;
        _timeBar.sprite = backgroundData.TimeBarSprite;
    }

    public static string GetNameCharacter() => _characterData.Name;
}
