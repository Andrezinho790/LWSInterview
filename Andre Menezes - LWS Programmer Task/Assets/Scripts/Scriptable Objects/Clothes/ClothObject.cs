using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClothType
{
    Hat,
    Shirt,
    Pants,
    Shoe
}
public abstract class ClothObject : ScriptableObject
{
    public GameObject prefab;
    public ClothType type;
    public int purchasePrice;
    public int salePrice;
    [TextArea(1, 2)]
    public string name;
    [TextArea(5,20)]
    public string description;
    public Sprite icon;
}
