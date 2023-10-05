using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private AudioSource audioPropulsor;
    [SerializeField] private AudioSource audioPropulsor2;
    [Header("Componentes")]
    public Rigidbody rb;
    public ParticleSystem particula;
    public ParticleSystem particula2;
    public ParticleSystem particulaInicial;
    public Energia energy;
    public Rotar rotar;
    public Rotar rotar2;

    [Header("Stats")]
    public float velocidadMovimiento;
    public float fuerzaRotacionZ;
    public float fuerzaImpulsoPlataforma;
    public float delay;
    float tiempo;

    [Space]
    public Vector2 direccionDe;
    public Vector2 direccionIz;

    [Header("Bools")]
    public bool moverseDe;
    public bool moverseIz;
    public bool sinEnergia;
    public bool impulsoPlataforma;
    public bool kinematic;
    void Start()
    {
        particula.Stop();
        particula2.Stop();
        audioPropulsor2.Stop();
        audioPropulsor.Stop();
        particulaInicial.Stop();
        impulsoPlataforma = true;
    }

    void Update()
    {
        if (tiempo > delay)
        {
            if (moverseDe)
            {
                transform.Rotate(0, 0, fuerzaRotacionZ * Time.deltaTime);
                rb.AddForce(direccionIz * velocidadMovimiento * Time.deltaTime);
            }          
            if (moverseIz)
            {
                transform.Rotate(0, 0, -fuerzaRotacionZ * Time.deltaTime);
                rb.AddForce(direccionDe * velocidadMovimiento * Time.deltaTime);
            }      
            
            if (!impulsoPlataforma)
            {
                rotar.encender = true;
                rotar2.encender = true;
            }
            audioPropulsor2.Stop();
            particulaInicial.Stop();
            particula2.Stop();
        }
        if (sinEnergia)
        {
            rotar.encender = false;
            rotar2.encender = false;
            PropulsorDeEnd();
            PropulsorIzEnd();
        }
        if (kinematic)
		{
            rb.isKinematic = true;
        }

        tiempo += Time.deltaTime;
    }

    void Salto()
    {
        audioPropulsor2.Play();
        particulaInicial.Play();
        particula2.Play();
        rb.AddForce(Vector3.up * fuerzaImpulsoPlataforma, ForceMode.Impulse);
        impulsoPlataforma = false;
        tiempo = 0;
    }


    //Botones Comienzo
    public void PropulsorDe()
    {
        moverseDe = true;
        particula.Play();
        audioPropulsor.Play();

        if (impulsoPlataforma)
        {
            Salto();
        }
    }

    public void PropulsorIz()
    {
        moverseIz = true;
        particula.Play();
        audioPropulsor.Play();

        if (impulsoPlataforma)
        {
            Salto();
        }
    }

    //Botones Fin
    public void PropulsorDeEnd()
    {
        audioPropulsor.Stop();
        particula.Stop();
        moverseDe = false;
    }
    public void PropulsorIzEnd()
    {
        audioPropulsor.Stop();
        particula.Stop();
        moverseIz = false;
    }
}
