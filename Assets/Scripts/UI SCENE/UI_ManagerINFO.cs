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

    private void Awake()
    {
        playerInfo.Awake();
    }
    private void Update()
    {
        ActualizarUI();
        playerInfo.ActualizarNivel();
    }

    public void ActualizarUI()
    {
        textNivel.text = playerInfo.nivel.ToString();
        textEnergia.text = playerInfo.energia.ToString() + "/" + playerInfo.energiaMaxima.ToString();
        textMagia.text = playerInfo.PuntosMagia.ToString();

        float fillAmountBarraExp = (float)playerInfo.puntosExperiencia / (float)playerInfo.puntosMaximoExperiencia;
        BarraExp.fillAmount = fillAmountBarraExp;

        float fillAmountBarraEnergia = (float)playerInfo.energia / (float)playerInfo.energiaMaxima;
        BarraEnergia.fillAmount = fillAmountBarraEnergia;
    }

    public void gastarEnergia()
    {
        playerInfo.energia = +50;
    }
}
