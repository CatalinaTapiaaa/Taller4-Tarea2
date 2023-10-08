using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform pivotPlayer;
    public Transform pivotAtaque;
    public Lengua lengua;

    [Header("Salto")]
    public float ancho;
    public float largo;
    [Space]
    public float fuerzaSalto;
    public float fuerzaSaltoMaximo;
    public float velocidadAtaque;
    public bool muerte, stop;

    Rigidbody2D rb2D;
    Vector2 startPos;
    float maxTapTime = 0.2f;
    float tapTime, salto;
    bool pressed;
    public bool saltar, noSaltar, noAtacar;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        noSaltar = true;
    }

    void Update()
    {
        if (muerte)
        {
            Destroy(gameObject);
        }

        if (!stop)
        {
            if (Input.touchCount > 0)
            {
                Touch dedo = Input.GetTouch(0);

                if (dedo.phase == TouchPhase.Began)
                {
                    tapTime = 0;
                    pressed = true;
                    startPos = dedo.position;
                }
                else if (dedo.phase == TouchPhase.Ended)
                {
                    pressed = false;
                    pivotPlayer.localScale = new Vector2(1, 1);

                    if (saltar)
                    {
                        Saltar();
                        salto = 0;
                        saltar = false;
                        noSaltar = false;
                        noAtacar = false;
                    }

                    if (tapTime < maxTapTime)
                    {
                        Vector2 deltaPos = dedo.position - startPos;
                        Vector2 inicio = startPos;

                        if (deltaPos.magnitude > 10)
                        {
                            if (!noAtacar)
                            {
                                Vector3 dedoPosicion = inicio;
                                dedoPosicion = Camera.main.ScreenToWorldPoint(dedoPosicion);
                                Vector2 direccion = new Vector2(dedoPosicion.x - pivotAtaque.position.x, dedoPosicion.y - pivotAtaque.position.y);
                                pivotAtaque.up = direccion;
                                noAtacar = true;
                                lengua.atacar = true;
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
                            salto += Time.deltaTime;

                            float escala = 0.1f * salto;
                            float escalaX = Mathf.Min(ancho, pivotPlayer.localScale.x + escala);
                            float escalaY = Mathf.Max(largo, pivotPlayer.localScale.y - escala);
                            pivotPlayer.localScale = new Vector2(escalaX, escalaY);

                            saltar = true;
                        }
                    }
                }
            }
        }              
    }

    void Saltar()
    {
        noSaltar = true;

        if (salto < fuerzaSaltoMaximo)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, salto * fuerzaSalto));
        }
        if (salto >= fuerzaSaltoMaximo)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, fuerzaSaltoMaximo * fuerzaSalto));
        }
    }      
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            noSaltar = false;
            noAtacar = true;
        }
    }

}
