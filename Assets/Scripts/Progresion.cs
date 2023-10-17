using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    public Spawn spawn;
    public GameObject componente;
    public Controlador controlador;
    [Space]
    [Header("Cantidad en pantalla")]
    public int nivelFacil;
    public int buenoFacil, maloFacil;
    [Space]
    public int nivelMedio;
    public int buenoMedio, maloMedio;
    [Space]
    public int nivelDificil;
    public int buenoDificil, maloDificil;


    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        if (controlador.puntuacion == nivelFacil)
        {
            spawn.cantidadEnPantallaBueno = buenoFacil;
            spawn.cantidadEnPantallaMalo = maloFacil;
        }
        if (controlador.puntuacion == nivelMedio)
        {
            spawn.cantidadEnPantallaBueno = buenoMedio;
            spawn.cantidadEnPantallaMalo = maloMedio;
        }
        if (controlador.puntuacion == nivelDificil)
        {
            spawn.cantidadEnPantallaBueno = buenoDificil;
            spawn.cantidadEnPantallaMalo = maloDificil;
        }
    }
}
