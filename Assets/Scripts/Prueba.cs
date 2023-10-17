using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Prueba : MonoBehaviour
{    
    public float velocidad;
    public float rango;

    GameObject[] pivots, pivotsDe, pivotsIz;
    GameObject[] pivotsTotal;
    int current;
    public bool de, iz;

    void Start()
    {
        pivots = GameObject.FindGameObjectsWithTag("Pivots");
        pivotsDe = GameObject.FindGameObjectsWithTag("De");
        pivotsIz = GameObject.FindGameObjectsWithTag("Iz");

        if (transform.position.x < 0)
        {
            pivotsTotal = pivots.Concat(pivotsDe).ToArray();
            iz = true;
        }
        if (transform.position.x > 0)
        {
            pivotsTotal = pivots.Concat(pivotsIz).ToArray();
            de = true;
        }

        NuevaPosicion();
    }

    void Update()
    {
        Vector3 targetPosition = pivotsTotal[current].transform.position;
        float t = velocidad * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 1)
        {
            NuevaPosicion();
        }
    }

    void NuevaPosicion()
    {
        current = Random.Range(0, pivotsTotal.Length);
    }
}
