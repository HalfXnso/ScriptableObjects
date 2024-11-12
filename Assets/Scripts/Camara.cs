using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset; // Offset from the player (set this in the Inspector to maintain the desired relative position)

    void LateUpdate()
    {
        if (player != null)
        {
            // Keep the camera at the same offset position relative to the player
            transform.position = player.position + offset;
        }
    }
}