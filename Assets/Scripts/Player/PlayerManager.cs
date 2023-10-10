using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool muerte;
    public Transform[] puntos;
    public LineRendererController line;
    public GameObject lineRenderer;

    void Start()
    {
        line.SetUpLine(puntos);
    }

    void Update()
    {
        if (muerte)
        {
            Destroy(gameObject);
            Destroy(lineRenderer);
        }
    }
}
