using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del personaje
    public float rotationSpeed = 720f;  // Velocidad de rotación del personaje

    private void Update()
    {
        // Input horizontal y vertical
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Direccion de movimiento
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Si hay movimiento
        if (direction.magnitude >= 0.1f)
        {
            // Calcular la rotación hacia la dirección de movimiento
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Suavizar la rotación
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Mover al personaje hacia adelante
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
