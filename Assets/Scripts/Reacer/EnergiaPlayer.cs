using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaPlayer : MonoBehaviour
{
    [Header("Componentes")]
    public Image barraEnergia;
    public MovimientoPlayer movimientoPlayer;

    [Header("Stats")]
    public float energiaMax;
    public float gastoEnergia;
    public bool gastarEnergiaDe, gastarEnergiaIz, reponerEnergia;

    float tiempo;

    void Start()
    {
        tiempo = energiaMax;
    }

    void Update()
    {
        if (reponerEnergia)
        {
            energiaMax = 100f;
            tiempo = 100f;
            if (tiempo == 100)
            {
                reponerEnergia = false;
            }
        }

        if (gastarEnergiaDe)
        {
            tiempo -= gastoEnergia * Time.deltaTime;
            if (tiempo <= 0)
            {
                movimientoPlayer.sinEnergia = true;
            }
        }

        if (gastarEnergiaIz)
        {
            tiempo -= gastoEnergia * Time.deltaTime;
            if (tiempo <= 0)
            {
                movimientoPlayer.sinEnergia = true;
            }
        }

        barraEnergia.fillAmount = tiempo / energiaMax;
    }

    public void GastarEnergiaDe()
    {
        gastarEnergiaDe = true;
    }

    public void GastarEnergiaDeEnd()
    {
        gastarEnergiaDe = false;
    }

    public void GastarEnergiaIz()
    {
        gastarEnergiaIz = true;
    }

    public void GastarEnergiaIzEnd()
    {
        gastarEnergiaIz = false;
    }
}
