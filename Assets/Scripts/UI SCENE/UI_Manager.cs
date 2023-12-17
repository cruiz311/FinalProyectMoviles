using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Button loadSceneButton;

    private void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        Scene_Manager.Instance.LoadSceneAsync("Juego");
    }
}
