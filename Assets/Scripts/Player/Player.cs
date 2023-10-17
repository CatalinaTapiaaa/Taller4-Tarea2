using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform inicioLengua;
    public Transform finalLengua;
    public Lengua lengua;
    [Space]
    public float velocidadAtaque;
    public bool atacar, noAtacar, stop, gameOver;

    float tapTime;
    float maxTapTime = 0.5f;  

    void Update()
    {
        finalLengua.rotation = inicioLengua.rotation;

        if (!gameOver)
        {
            if (atacar)
            {
                finalLengua.position += finalLengua.up * velocidadAtaque * Time.deltaTime;
                lengua.enabled = true;
                noAtacar = true;
            }
            if (!atacar)
            {
                finalLengua.position = Vector2.MoveTowards(finalLengua.position, inicioLengua.position, velocidadAtaque * Time.deltaTime);
            }
            if (noAtacar)
            {
                if (finalLengua.position == inicioLengua.position)
                {
                    noAtacar = false;
                }
            }

            if (!stop)
            {
                if (Input.touchCount > 0)
                {
                    Touch dedo = Input.GetTouch(0);

                    if (dedo.phase == TouchPhase.Began)
                    {
                        tapTime = 0;
                    }
                    else if (dedo.phase == TouchPhase.Ended)
                    {
                        if (tapTime < maxTapTime)
                        {
                            Vector3 deltaPos = dedo.position;
                            Vector3 inicio = deltaPos;

                            if (deltaPos.magnitude > 10)
                            {
                                if (!noAtacar)
                                {
                                    Debug.Log("Tap");

                                    Vector3 dedoPosicion = inicio;
                                    dedoPosicion = Camera.main.ScreenToWorldPoint(dedoPosicion);
                                    Vector2 direccion = new Vector2(dedoPosicion.x - inicioLengua.position.x, dedoPosicion.y - inicioLengua.position.y);
                                    inicioLengua.up = direccion;

                                    atacar = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }        
}

