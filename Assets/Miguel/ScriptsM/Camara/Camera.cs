using UnityEngine;

public class Camera:MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Vector3 offset;

    void Update()
    {
        if (player != null)
        {
            // Obtener la posici�n del jugador
            transform.position = player.position + offset;
        }
    }
}
