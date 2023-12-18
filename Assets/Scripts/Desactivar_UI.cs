using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Desactivar_UI : MonoBehaviour
{
    public GameObject uiObject;

    public void ActivarDesactivarUI()
    {
        // Alternar entre activar y desactivar el objeto UI
        if (uiObject != null)
        {
            uiObject.SetActive(!uiObject.activeSelf);
        }
    }
}
