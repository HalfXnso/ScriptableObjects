using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public InventoryObject playerInventory;   // El inventario del jugador
    public CraftingRecipe recipe;             // La receta que se requiere para craftear
    public Button craftButton;                // El botón de crafteo

    private void Start()
    {
        craftButton.onClick.AddListener(CraftItem); // Asigna la función al botón
    }

    public void CraftItem()
    {
        // Verifica si el jugador tiene los ingredientes necesarios
        if (playerInventory.HasIngredients(recipe))
        {
            // Remueve los ingredientes y agrega el objeto crafteado
            playerInventory.RemoveIngredients(recipe);
            playerInventory.AddItem(recipe.resultItem, recipe.resultAmount);

            Debug.Log("Objeto crafteado: " + recipe.resultItem.name);
        }
        else
        {
            Debug.Log("No tienes los materiales necesarios para craftear.");
        }
    }
}
