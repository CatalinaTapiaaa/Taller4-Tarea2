using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform[] puntos;
    public Linea line;

    void Start()
    {
        line.SetUpLine(puntos);
    }   
}
