using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDe : MonoBehaviour
{
    public float tiempo;
    [Header("Componentes")]
    public float tiempoPanel;
    public ParticleSystem par;
    public ParticleSystem par1;

    [Header("Componentes")]
    public Player player;
    public Movimiento movimiento;
    [Space]
    public GameObject x;
    public Animator aniX;

    [Header("Bools")]
    public bool camaraLenta;
    public bool playerTrigger, playerCollision;
    public bool victory;

    float timer;

    private void Start()
    {
        par.Stop();
        par1.Stop();
    }

    void Update()
    {       
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        timer += Time.deltaTime;
        if (timer >= tiempo)
        {
            if (enemigos.Length == 0)
            {
                aniX.SetBool("Muerte", true);
                gameObject.tag = "Plataforma";

                if (playerTrigger)
                {
                    camaraLenta = true;
                    victory = true;
                }
                if (playerCollision)
                {
                    player.noControl = true;
                    movimiento.kinematic = true;
                    movimiento.sinEnergia = true;          
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = true;
            if (victory)
            {
                par1.Play();
            }
        }
    }   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollision = true;
            par.Play();
        }
    }  
}
