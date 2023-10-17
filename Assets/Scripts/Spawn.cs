using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pivot;
    [Header("Bueno")]
    public GameObject itemBueno;
    public float tiempoSpawnBueno;
    public int cantidadEnPantallaBueno;
    public bool activarBueno;
    [Header("Malo")]
    public GameObject itemMalo;
    public float tiempoSpawnMalo;
    public int cantidadEnPantallaMalo;
    public bool activarMalo;

    float t1, t2;

    void Start()
    {
        t1 = tiempoSpawnBueno;
        t2 = tiempoSpawnMalo;
    }

    void Update()
    {
        GameObject[] item1 = GameObject.FindGameObjectsWithTag("ItemBlanco");
        GameObject[] item2 = GameObject.FindGameObjectsWithTag("ItemRojo");

        if (activarBueno)
        {
            if (item1.Length < cantidadEnPantallaBueno)
            {
                t1 += Time.deltaTime;

                if (t1 >= tiempoSpawnBueno)
                {
                    int aleatorio = Random.Range(0, pivot.Length);
                    Instantiate(itemBueno, pivot[aleatorio].position, Quaternion.identity);
                    t1 = 0;
                }
            }           
        }
        if (activarMalo)
        {
            if (item2.Length < cantidadEnPantallaMalo)
            {
                t2 += Time.deltaTime;

                if (t2 >= tiempoSpawnMalo)
                {
                    int aleatorio = Random.Range(0, pivot.Length);
                    Instantiate(itemMalo, pivot[aleatorio].position, Quaternion.identity);
                    t2 = 0;
                }
            }            
        }
    }
}
