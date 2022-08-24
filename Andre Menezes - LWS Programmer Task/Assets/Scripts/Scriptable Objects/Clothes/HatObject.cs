using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Hat Cloth", menuName = "Inventory System/Clothes/Hat")]
public class HatObject : ClothObject
{
    private void Awake()
    {
        type = ClothType.Hat;
    }
}
