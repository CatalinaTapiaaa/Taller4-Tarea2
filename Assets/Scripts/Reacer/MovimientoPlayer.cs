using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody rb;
    public ParticleSystem particulaIz, particulaDe;

    [Header("Stats")]
    public float fuerzaImpulso;
    public float fuerzaRotacion;
    public float fuerzaImpulsoPlataforma;
    public Vector2 direccionDe, direccionIz;

    public bool fuerzaDe, fuerzaIz, sinEnergia, impulsoPlataforma;
    public bool salto;

    public float delay = 1;
    float t;

    void Start()
    {
        particulaIz.Stop();
        particulaDe.Stop();
    }

    void Update()
    {

        if(t > delay)
        {
            if (fuerzaDe)
            {
                transform.Rotate(0, 0, fuerzaRotacion * Time.deltaTime);
                rb.AddForce(direccionIz * fuerzaImpulso * Time.deltaTime);
            }

            if (fuerzaIz)
            {
                transform.Rotate(0, 0, -fuerzaRotacion * Time.deltaTime);
                rb.AddForce(direccionDe * fuerzaImpulso * Time.deltaTime);
            }
        }


            if (sinEnergia)
            {
                PropulsorDeEnd();
                PropulsorIzEnd();
            }
        
  
            t+= Time.deltaTime;
    }

    public void PropulsorDe()
    {
        fuerzaDe = true;
        particulaDe.Play();

        if(impulsoPlataforma)
        {
            Salto();
        }
        //salto = true;
    }

    public void PropulsorDeEnd()
    {
        fuerzaDe = false;
        particulaDe.Stop();

        //salto = false;
    }

    public void PropulsorIz()
    {
        fuerzaIz = true;
        particulaIz.Play();

        if (impulsoPlataforma)
        {
            Salto();
        }

    }

    public void PropulsorIzEnd()
    {
        fuerzaIz = false;
        particulaIz.Stop();

    }

    void Salto()
    {
        rb.AddForce(Vector3.up * fuerzaImpulsoPlataforma , ForceMode.Impulse);
        impulsoPlataforma = false;
        sinEnergia = false;
        t = 0;
    }
}
