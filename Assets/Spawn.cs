using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawn : MonoBehaviour
{
    public GameObject pinchos;
    public GameObject moscas;
    public Transform[] pivot;

    void Start()
    {
        Facil();
    }

    void Facil()
    {
        for (int i = 0; i < 2; i++)
        {
            int aleatorio = Random.Range(0, pivot.Length);
            Instantiate(pinchos, pivot[aleatorio].position, Quaternion.identity);
        }
        for (int i = 0; i < 2; i++)
        {
            int aleatorio = Random.Range(0, pivot.Length);
            Instantiate(moscas, pivot[aleatorio].position, Quaternion.identity);
        }
    }
}
