using UnityEngine;

public class IsometricMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento

    // Variables de referencia para el control
    private Vector3 forward, right;

    void Start()
    {
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
