using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Shoe Cloth", menuName = "Inventory System/Clothes/Shoe")]
public class ShoeObject : ClothObject
{
    private void Awake()
    {
        type = ClothType.Shoe;
    }

}
