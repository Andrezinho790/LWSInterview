using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shirt Cloth", menuName = "Inventory System/Clothes/Shirt")]
public class ShirtObject : ClothObject
{
    private void Awake()
    {
        type = ClothType.Shirt;
    }
}
