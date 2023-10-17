using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
<<<<<<< HEAD
    public Transform[] puntos;
    public Linea line;

    void Start()
=======
    public bool muerte;
    public Transform[] puntos;
    public LineRendererController line;
    public GameObject lineRenderer;

    void Start()
    {
        line.SetUpLine(puntos);
    }

    void Update()
>>>>>>> 448f8f8ed44dea1263ff755ab35d3cffba636b9d
    {
        line.SetUpLine(puntos);
    }   
}
