using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "All Clothes Object", menuName = "Inventory System/Clothes Base")]
public class CharacterAllClothes : ScriptableObject
{
    public List<ClothBaseInfo> AllClothesBase;
}
[System.Serializable]
public class ClothBaseInfo
{
    public ClothType part;
    public ClothObject partReference;
}
