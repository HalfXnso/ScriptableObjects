using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    // Añadir un ítem al inventario
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public bool HasItem(ItemObject _item)
        {
            foreach (InventorySlot slot in Container)
            {
                if (slot.item == _item)
                {
                    return true;
                }
            }
            return false;
        }
    
    // Verificar si tienes los ingredientes necesarios para craftear
    public bool HasIngredients(CraftingRecipe recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            bool found = false;
            foreach (var slot in Container)
            {
                if (slot.item == ingredient.item && slot.amount >= ingredient.amount)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false; // Si falta algún ingrediente o cantidad, retorna false
            }
        }

        return true; // Si todos los ingredientes están presentes, retorna true
    }

    // Remover los ingredientes necesarios del inventario
    public void RemoveIngredients(CraftingRecipe recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].item == ingredient.item)
                {
                    Container[i].amount -= ingredient.amount;

                    
                }
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
