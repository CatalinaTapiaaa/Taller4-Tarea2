using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public float velocidad;
    public bool encender;
    private void Update()
    {
        if (encender)
        {
            transform.Rotate(0, -velocidad * Time.deltaTime, 0);
        }
    }    
}
