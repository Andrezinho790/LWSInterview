using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddCloth(ClothObject _cloth)
    {
        Container.Add(new InventorySlot(_cloth));
    }
}

[System.Serializable]
public class InventorySlot
{
    public ClothObject cloth;
    public InventorySlot(ClothObject _cloth)
    {
        cloth = _cloth;
    }
}
