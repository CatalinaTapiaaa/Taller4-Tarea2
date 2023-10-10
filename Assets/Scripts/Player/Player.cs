using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LevelCreator levelCreator;
    public Lengua lengua;
    public Transform pivotPlayer;
    public Transform pivotAtaque;
    public TrailRenderer[] trails;

    [Header("Salto")]
    [Space]
    public float fuerzaSalto;
    public float fuerzaSaltoMaximo;
    public float velocidadAtaque;
    public bool stop, reiniciar;

    Rigidbody2D rb2D;
    Vector2 startPos;
    float maxTapTime = 0.2f;
    public float tapTime, salto;
    bool pressed;
    public bool saltar, noSaltar, noAtacar;
    float escala1, escala2;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        noSaltar = true;
        foreach (TrailRenderer trail in trails)
        {
            trail.enabled = false;
        }
    }

    void Update()
    {
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

                    if (saltar)
                    {
                        pivotPlayer.localScale = new Vector2(1, 1);

                        Saltar();
                        salto = 0;
                        saltar = false;
                        noSaltar = true;
                        noAtacar = false;
                    }                    

                    if (tapTime < maxTapTime)
                    {
                        Vector3 deltaPos = dedo.position;
                        Vector3 inicio = deltaPos;

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

                            float escala = 0.01f * salto;
                            float escalaX = Mathf.Min(1.5f, pivotPlayer.localScale.x + escala);
                            float escalaY = Mathf.Max(0.5f, pivotPlayer.localScale.y - escala);
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
        GameObject[] moscas = GameObject.FindGameObjectsWithTag("Mosca");

        if (collision.gameObject.CompareTag("Piso"))
        {
            noAtacar = true;
            noSaltar = false;

            foreach (TrailRenderer trail in trails)
            {
                trail.enabled = false;
            }

            if (reiniciar)
            {
                if (moscas.Length == 0)
                {
                    levelCreator.cerrarNivel = true;
                    reiniciar = false;
                }
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        GameObject[] moscas = GameObject.FindGameObjectsWithTag("Mosca");

        if (collision.gameObject.CompareTag("Piso"))
        {                        

            if (reiniciar)
            {
                if (moscas.Length == 0)
                {
                    levelCreator.cerrarNivel = true;
                    reiniciar = false;
                }
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            noSaltar = true;

            foreach (TrailRenderer trail in trails)
            {
                trail.enabled = true;
            }
        }
    }
  
}
