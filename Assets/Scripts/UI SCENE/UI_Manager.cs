using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public void CargarScene(string nameScena)
    {
        Scene_Manager.Instance.LoadSceneAsync(nameScena);
    }
}
