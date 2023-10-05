using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlataforma : MonoBehaviour
{
    [Header("Objetos")]
    public GameObject luzDe;
    public GameObject luzIz;

    [Header("Colores")]
    public Material noDisponible;
    public Material disponible;
    public Material ocupado;

    [Header("Bools")]
    public bool noDisponibleDe, disponibleDe, ocupadoDe;
    public bool noDisponibleIz, disponibleIz, ocupadoIz;


    private void Start()
    {
        ocupadoDe = true;
    }

    private void Update()
    {
        if (noDisponibleDe)
        {
            //se enciende al ocupadoIz es true
            //elimina a todos los enemigos y cambia a disponibleDe
            //material
        }
        if (disponibleDe)
        {
            noDisponibleDe = false;
            //estara disponible hasta estacionar en la plataforma
            //material
        }
        if (ocupadoDe)
        {
            noDisponibleIz = true;
            disponibleDe = false;
            ocupadoIz = false;
            //se queda ocupadoDE hasta que ocupadoIZ la otra plataforma
            //material
        }


        if (noDisponibleIz)
        {

        }
        if (disponibleIz)
        {
            noDisponibleIz = false;


        }
        if (ocupadoDe)
        {
            noDisponibleDe = true;
            disponibleIz = false;
            ocupadoDe = false;

        }

    }

}
