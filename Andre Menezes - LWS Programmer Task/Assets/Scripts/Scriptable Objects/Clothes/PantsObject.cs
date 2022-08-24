using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pants Cloth", menuName = "Inventory System/Clothes/Pantss")]
public class PantsObject : ClothObject
{
    private void Awake()
    {
        type = ClothType.Pants;
    }
}
