using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Salto")]
    public float fuerza;
    public float fuerzaSalto;
    public float fuerzaMaximaSalto;

    [Header("Ataque")]

    Rigidbody2D rb2D;
    Vector2 startPos;
    float maxTapTime = 0.5f;
    float tapTime;
    bool pressed;
    bool noSaltar, noAtacar;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        noAtacar = true;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch dedo = Input.GetTouch(0);

            if (dedo.phase == TouchPhase.Began)
            {
                tapTime = 0;
                fuerzaSalto = 0;
                pressed = true;
                startPos = dedo.position;
            }
            else if (dedo.phase == TouchPhase.Ended)
            {
                pressed = false;

                if (tapTime >= maxTapTime)
                {
                    Saltar();
                }

                if (tapTime < maxTapTime)
                {
                    Vector2 deltaPos = dedo.position - startPos;

                    if (deltaPos.magnitude > 10)
                    {
                        if (Mathf.Abs(deltaPos.x) > Mathf.Abs(deltaPos.y))
                        {
                            noAtacar = true;
                        }                      
                    }
                }
            }

            if (pressed)
            {
                if (!noSaltar)
                {
                    tapTime += Time.deltaTime;

                    if (tapTime >= maxTapTime)
                    {
                        Debug.Log("Presionando");
                        fuerzaSalto += Time.deltaTime;   
                    }
                }             
            }
        }                    
    }

    void Saltar()
    {
        noAtacar = false;

        if (fuerzaSalto < fuerzaMaximaSalto)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, fuerzaSalto * fuerza));
        }
        if (fuerzaSalto > fuerzaMaximaSalto)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, fuerzaMaximaSalto * fuerza));
        }
    }
    void Atacar()
    {
       
    }
}

