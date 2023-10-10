using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoLengua : MonoBehaviour
{
    public Transform[] puntos;
    public LineRendererController line;

    void Start()
    {
        line.SetUpLine(puntos);
    }
}
