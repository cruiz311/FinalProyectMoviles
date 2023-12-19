using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_ManagerINFO : MonoBehaviour
{
    public PlayerInfoUi playerInfoUi;
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
        playerInfoUi.Awake();

    }
    private void Update()
    {
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        textNivel.text = playerInfoUi.nivel.ToString();
        textEnergia.text = playerInfoUi.energia.ToString() + "/" + playerInfoUi.energiaMaxima.ToString();
        textMagia.text = playerInfoUi.PuntosMagia.ToString();

        float fillAmountBarraExp = (float)playerInfoUi.puntosExperiencia / (float)playerInfoUi.puntosMaximoExperiencia;
        BarraExp.fillAmount = fillAmountBarraExp;

        float fillAmountBarraEnergia = (float)playerInfoUi.energia / (float)playerInfoUi.energiaMaxima;
        BarraEnergia.fillAmount = fillAmountBarraEnergia;
    }

    public void gastarEnergia()
    {
        playerInfoUi.energia = +50;
    }
}
