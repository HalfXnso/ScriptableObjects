using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;  // Referencia al Animator de la puerta
    public InventoryObject playerInventory;  // Referencia al inventario del jugador
    public ItemObject requiredItem;  // El objeto necesario (por ejemplo, la llave)
    
    void Update()
    {
        // Verifica si el jugador tiene la llave y presiona el botón para abrir la puerta
        if (playerInventory.HasItem(requiredItem))  // Puedes usar otro botón si lo deseas
        {
            Debug.Log(requiredItem.name +" Conseguido");
            doorAnimator.SetTrigger("hasKey"); // Activa el trigger en el Animator para abrir la puerta
        }
    }
}
