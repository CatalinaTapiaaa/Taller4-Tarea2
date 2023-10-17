using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pivot;
    [Header("Circulo Blanco")]
    public GameObject itemBlanco;
    public float tiempoSpawnBlanco;
    public int cantidadItemBlanco;
    public bool activarBlanco;
    [Header("Circulo Rojo")]
    public GameObject itemRojo;
    public float tiempoSpawnRojo;
    public int cantidadItemRojo;
    public bool activarRojo;

    float t1, t2;

    void Start()
    {
        t1 = tiempoSpawnBlanco;
        t2 = tiempoSpawnRojo;
    }

    void Update()
    {
        if (activarBlanco)
        {
            t1 += Time.deltaTime;

            if (t1 >= tiempoSpawnBlanco)
            {
                int aleatorio = Random.Range(0, pivot.Length);
                Instantiate(itemBlanco, pivot[aleatorio].position, Quaternion.identity);
                t1 = 0;
            }
        }
        if (activarRojo)
        {
            t2 += Time.deltaTime;

            if (t2 >= tiempoSpawnRojo)
            {
                int aleatorio = Random.Range(0, pivot.Length);
                Instantiate(itemRojo, pivot[aleatorio].position, Quaternion.identity);
                t2 = 0;
            }
        }
    }
}
