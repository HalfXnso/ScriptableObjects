using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Objeto por defecto")]
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.ObjetoPorDefecto;
    }

}
