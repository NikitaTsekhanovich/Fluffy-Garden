using UnityEngine;

public interface IItem
{
    public int Price { get; }
    public bool IsOpen { get; set; }
    public bool IsChosen { get; set; }
    public Sprite Sprite { get; }
}
