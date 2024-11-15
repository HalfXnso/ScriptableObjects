using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public GameObject canvasInventario; // Referencia al Canvas de inventario
    private bool inventarioActivo = false;
    private Rigidbody rb;
    // Variables de referencia para el control
    private Vector3 forward, right;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody
        // Ajustar las direcciones para el movimiento en isométrico
        forward = Camera.main.transform.forward;
        forward.y = 0; // No queremos que suba o baje
        forward = Vector3.Normalize(forward);
 
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }
 
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
if (Input.GetKeyDown(KeyCode.I))
        {
            // Cambia el estado de activación del inventario
            inventarioActivo = !inventarioActivo;
           
            // Activa o desactiva el Canvas de inventario según el estado
            canvasInventario.SetActive(inventarioActivo);
        }
    }
 
    void Move()
    {
        // Obtener input del teclado
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
 
        // Calcular la dirección en isométrico
        Vector3 rightMovement = right * direction.x;
        Vector3 upMovement = forward * direction.z;
 
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
 
        // Mover al personaje
        transform.position += heading * moveSpeed * Time.deltaTime;
 
        // Si quieres que el personaje rote en la dirección que se mueve
        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }
    }
}