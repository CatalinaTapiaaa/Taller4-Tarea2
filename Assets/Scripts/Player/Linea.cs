using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
    LineRenderer line;
    Transform[] points;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    public void SetUpLine(Transform[] puntos)
    {
        line.positionCount = puntos.Length;
        this.points = puntos;
    }    
    void Update()
    {
        if (points != null)
        {
            for (int i = 0; i < points.Length; i++)
            {
                line.SetPosition(i, points[i].position);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemBlanco"))
        {

        }
        if (collision.gameObject.CompareTag("ItemRojo"))
        {

        }

        if (collision.gameObject.CompareTag("Pared"))
        {

        }
    }
}
