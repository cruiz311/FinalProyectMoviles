using UnityEngine;

[CreateAssetMenu(fileName = "PuntuacionesSO", menuName = "Puntuaciones Data", order = 1)]
public class PuntuacionesSO : ScriptableObject
{
    public int enemigosMatados;
    public int mapasSuperados;

    public void Awake()
    {
        enemigosMatados = 0;
        mapasSuperados = 0;
    }
}
