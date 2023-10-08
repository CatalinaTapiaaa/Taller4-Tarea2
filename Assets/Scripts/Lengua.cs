using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    public BarraProgreso barraProgreso;
    public Player player;
    public Transform pivotAtaque;
    [Space]
    public float velocidadAtaque;
    public bool atacar;
    bool desactivar;

    void Update()
    {
        transform.rotation = pivotAtaque.rotation;

        if (atacar)
        {
            transform.position += transform.up * velocidadAtaque * Time.deltaTime;
            desactivar = true;
        }
        if (!atacar)
        {
            transform.position = Vector2.MoveTowards(transform.position, pivotAtaque.position, velocidadAtaque * Time.deltaTime);
        }

        if (desactivar)
        {
            if (transform.position == pivotAtaque.position)
            {
                player.noAtacar = false;
                desactivar = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mosca"))
        {
            barraProgreso.t1 += 1;
            atacar = false;
        }
        if (collision.gameObject.CompareTag("Pared"))
        {
            atacar = false;
        }
        if (collision.gameObject.CompareTag("Pincho"))
        {
            player.muerte = true;
        }
    }
}
