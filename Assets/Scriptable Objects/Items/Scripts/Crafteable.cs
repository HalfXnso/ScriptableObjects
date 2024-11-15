using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Objeto Crafteable")]

public class Crafteable : ItemObject
{
    public List<GameObject> objetosNecesarios;
    public void Awake()
    {
        type = ItemType.ObjetoCrafteable;

    }
   
}
