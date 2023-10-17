using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    public int cambiarDificultad;
    [Header("Facil")]
    public float tiempoSpawnBlancoFacil;
    public int cantidadBlancoFacil;
    [Space]
    public float tiempoSpawnRojoFacil;
    public int cantidadRojoFacil;
    [Header("Normal")]
    public float tiempoSpawnBlancoNormal;
    public int cantidadBlancoNormal;
    [Space]
    public float tiempoSpawnRojoNormal;
    public int cantidadRojoNormal;
    [Header("Dificil")]
    public float tiempoSpawnBlancoDificil;
    public int cantidadBlancoDificil;
    [Space]
    public float tiempoSpawnRojoDificil;
    public int cantidadRojoDificil;
    [Space]
    [Space]
    public GameObject componente;
    public Controlador controlador;
    public Spawn spawn;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        if (controlador.puntuacion == cambiarDificultad)
        {
            spawn.tiempoSpawnBlanco = tiempoSpawnBlancoFacil;
            spawn.cantidadItemBlanco = cantidadBlancoFacil;

            spawn.tiempoSpawnRojo = tiempoSpawnRojoFacil;
            spawn.cantidadItemRojo = cantidadRojoFacil;
        }

        if (controlador.puntuacion == cambiarDificultad * 2)
        {
            spawn.tiempoSpawnBlanco = tiempoSpawnBlancoNormal;
            spawn.cantidadItemBlanco = cantidadBlancoNormal;

            spawn.tiempoSpawnRojo = tiempoSpawnRojoNormal;
            spawn.cantidadItemRojo = cantidadRojoNormal;
        }

        if (controlador.puntuacion == cambiarDificultad * 3)
        {
            spawn.tiempoSpawnBlanco = tiempoSpawnBlancoDificil;
            spawn.cantidadItemBlanco = cantidadBlancoDificil;

            spawn.tiempoSpawnRojo = tiempoSpawnRojoDificil;
            spawn.cantidadItemRojo = cantidadRojoDificil;
        }
    }
}
