using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    [Header("Componentes")]
    public Image barraEnergia;
    public Movimiento movimiento;

    [Header("Stats")]
    public float energiaMax;
    public float gastoEnergia;
    float tiempo;

    [Header("Bools")]
    public bool gastarEnergiaDe;
    public bool gastarEnergiaIz;

    void Start()
    {
        tiempo = energiaMax;
    }

    void Update()
    {   
        if (gastarEnergiaDe)
        {
            tiempo -= gastoEnergia * Time.deltaTime;
            if (tiempo <= 0)
            {
                movimiento.sinEnergia = true;
            }
        }
        if (gastarEnergiaIz)
        {
            tiempo -= gastoEnergia * Time.deltaTime;
            if (tiempo <= 0)
            {
                movimiento.sinEnergia = true;
            }
        }

        barraEnergia.fillAmount = tiempo / energiaMax;
    }


    //Botones Comienzo
    public void GastarEnergiaDe()
    {
        gastarEnergiaDe = true;
    }
    public void GastarEnergiaIz()
    {
        gastarEnergiaIz = true;
    }

    //Botones Final
    public void GastarEnergiaDeEnd()
    {
        gastarEnergiaDe = false;
    }
    public void GastarEnergiaIzEnd()
    {
        gastarEnergiaIz = false;
    }
}
