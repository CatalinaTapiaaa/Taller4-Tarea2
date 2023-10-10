using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public LevelCreator levelCreator;
    public Image barra;
    public float t1, current; //puntos
    public bool todasMoscas, sumar, activar;

    [Header("Puntuacion")]
    public GameObject componente;
    public Controlador controlador;

    public float barraMax;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        if (todasMoscas)
        {
            GameObject[] moscas = GameObject.FindGameObjectsWithTag("Mosca");
            barraMax = moscas.Length;
            todasMoscas = false;
        }

        if (activar)
        {
            if (t1 >= barraMax)
            {              
                t1 = 0;
                current = 0;
                controlador.puntuacion += 1;
                activar = false;
            }
        }               

        if (sumar)
        {
            t1 += Time.deltaTime;
            if (t1 >= current)
            {
                sumar = false;
            }
        }
   
        barra.fillAmount = t1 / barraMax;
    }
}
