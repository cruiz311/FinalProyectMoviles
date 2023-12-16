using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_ManagerINFO : MonoBehaviour
{
    public PlayerInfoUi playerInfo;
    [Header("nivel")]
    public TMP_Text textNivel;
    public Image BarraExp;
    [Header("energia")]
    public TMP_Text textEnergia;
    public Image BarraEnergia;
    [Header("magia")]
    public TMP_Text textMagia;

    private void Start()
    {
        textNivel.text = playerInfo.nivel.ToString();
    }
}
