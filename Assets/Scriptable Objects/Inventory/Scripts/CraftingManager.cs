using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public InventoryObject playerInventory;   // El inventario del jugador
    public CraftingRecipe recipe;             // La receta que se requiere para craftear
    public GameObject craftButtonObject;      // GameObject del botón de crafteo

    private Button craftButton;

    private void Start()
    {
        craftButton = craftButtonObject.GetComponent<Button>(); // Obtén el componente Button
        craftButton.onClick.AddListener(CraftItem);             // Asigna la función al botón
        craftButtonObject.SetActive(false);                     // Desactiva el botón al inicio

        // Verifica inmediatamente si el botón debe estar activo
        UpdateCraftButtonState();
    }

    private void Update()
    {
        UpdateCraftButtonState(); // Revisa constantemente el estado del botón (puedes optimizar esto)
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

        UpdateCraftButtonState(); // Asegúrate de actualizar el botón después de craftear
    }

    private void UpdateCraftButtonState()
    {
        // Activa o desactiva el botón de acuerdo a los ingredientes
        if (playerInventory.HasIngredients(recipe))
        {
            craftButtonObject.SetActive(true);  // Activa el botón si hay ingredientes suficientes
        }
        else
        {
            craftButtonObject.SetActive(false); // Desactiva el botón si faltan ingredientes
        }
    }
}
