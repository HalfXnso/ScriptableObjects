using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Crafting System/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<Ingredient> ingredients; // Lista de ingredientes necesarios
    public Crafteable resultItem;        // Objeto resultante al craftear
    public int resultAmount;             // Cantidad del objeto resultante
}

[System.Serializable]
public class Ingredient
{
    public ItemObject item;
    public int amount;
}
