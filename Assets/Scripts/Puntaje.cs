using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public Image barraProgreso;
    public float maxBarra;
    public bool sumarPuntos;
    [Space]
    [Header("Puntuacion")]
    public GameObject componente;
    public Controlador controlador;

    float t, current;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        if (sumarPuntos)
        {
            t += Time.deltaTime;

            if (t >= current)
            {
                current += 1;
                sumarPuntos = false;
            }
        }

        if (current == maxBarra)
        {
            t = 0;
            controlador.puntuacion += 1;
            current = 0;
        }

        barraProgreso.fillAmount = t / maxBarra;
    }
}
