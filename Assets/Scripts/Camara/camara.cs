using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target; // GameObject cuya posici�n Z se igualar�

    public float zOffset = -2f; // Offset que se sumar� a la posici�n Z

    void Update()
    {
        if (target != null)
        {
            // Mantener los valores actuales de la posici�n de la c�mara en los ejes X e Y
            Vector3 currentPosition = transform.position;
            currentPosition.x = transform.position.x;
            currentPosition.y = transform.position.y;

            // Igualar la posici�n Z con el objeto target y sumarle el offset
            currentPosition.z = target.position.z + zOffset;

            // Actualizar la posici�n de la c�mara
            transform.position = currentPosition;
        }
    }
}
