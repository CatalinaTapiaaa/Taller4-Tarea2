using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public LevelCreator levelCreator;
    public Image barra;
    public float t1;

    [Header("Puntuacion")]
    public GameObject componente;
    public Controlador controlador;

    bool reiniciaTiempo;
    float barraMax;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        GameObject[] moscas = GameObject.FindGameObjectsWithTag("Mosca");
        barraMax = moscas.Length;
            
        if (t1 >= barraMax)
        {
            controlador.puntuacion += 1;
            reiniciaTiempo = true;
        }

        if (reiniciaTiempo)
        {
            t1 -= Time.deltaTime;
            if (t1 <= 0)
            {
                reiniciaTiempo = false;
            }
        }

        barra.fillAmount = t1 / barraMax;
    }
}
