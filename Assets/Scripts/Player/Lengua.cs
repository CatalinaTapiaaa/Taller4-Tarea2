using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    public SpriteRenderer sprite;
    public BarraProgreso barraProgreso;
    public Player player;
    public PlayerManager playerManager;
    public Transform pivotAtaque;
    [Space]
    public float velocidadAtaque;
    public bool atacar;
    public bool desactivar;

    void Start()
    {
        sprite.enabled = false;
    }

    void Update()
    {
        transform.rotation = pivotAtaque.rotation;

        if (atacar)
        {
            transform.position += transform.up * velocidadAtaque * Time.deltaTime;
            sprite.enabled = true;
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
                sprite.enabled = false;
                desactivar = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mosca"))
        {
            barraProgreso.current += 1;
            barraProgreso.sumar = true;
            atacar = false;
        }
        if (collision.gameObject.CompareTag("Pared"))
        {
            atacar = false;
        }
        if (collision.gameObject.CompareTag("Pincho"))
        {
            playerManager.muerte = true;
        }
    }
}
