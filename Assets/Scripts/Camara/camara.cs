using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target; // GameObject cuya posición Z se igualará

    public float zOffset = -2f; // Offset que se sumará a la posición Z

    void Update()
    {
        if (target != null)
        {
            // Mantener los valores actuales de la posición de la cámara en los ejes X e Y
            Vector3 currentPosition = transform.position;
            currentPosition.x = transform.position.x;
            currentPosition.y = transform.position.y;

            // Igualar la posición Z con el objeto target y sumarle el offset
            currentPosition.z = target.position.z + zOffset;

            // Actualizar la posición de la cámara
            transform.position = currentPosition;
        }
    }
}
