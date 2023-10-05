using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioPropulsor;
    public TutorialUI tutorialUI;
    public Image barra;
    public ParticleSystem particula;
    [Space]
    public float rellenarBarra;
    public float fuerzaRotacionZ;
    public bool moverseDe;
    public bool moverseIz;
    float cargaMax = 100;

    public float tiempo;

    [Header("Botones")]
    public GameObject de;
    public GameObject iz;

    bool uno, dos, tres;
    void Start()
    {
        tiempo = cargaMax;
        uno = true;
        particula.Stop();
        audioPropulsor.Stop();
    }

    private void Update()
    {
        if (dos)
        {
            tiempo += 100 * Time.deltaTime;
            de.SetActive(false);

            if (tiempo >= 100)
            {
                iz.SetActive(true);
                dos = false;
            }
        }
        if (tres)
        {
            iz.SetActive(false);
            tiempo += 100 * Time.deltaTime;
            if (tiempo >= 100)
            {
                iz.SetActive(true);
                de.SetActive(true);
                tres = false;
            }
        }   


        if (uno)
        {
            if (moverseDe)
            {
                tiempo -= rellenarBarra * Time.deltaTime;
                transform.Rotate(0, 0, fuerzaRotacionZ * Time.deltaTime);

                if (tiempo <= 0)
                {
                    moverseDe = false;
                    dos = true;
                }
            }

            if (moverseIz)
            {
                tiempo -= rellenarBarra * Time.deltaTime;
                transform.Rotate(0, 0, -fuerzaRotacionZ * Time.deltaTime);

                if (tiempo <= 0)
                {
                    moverseIz = false;
                    uno = false;
                    tres = true;
                }
            }
        }
        else
        {
            if (moverseIz && moverseDe)
            {
                tiempo -= rellenarBarra * Time.deltaTime;

                if (tiempo <= 0)
                {
                    iz.SetActive(false);
                    de.SetActive(false);
                    moverseIz = false;
                    moverseDe = false;
                    tutorialUI.pasarGameplay = true;
                }
            }
        }

        barra.fillAmount = tiempo / cargaMax;
    }
    public void PropulsorDe()
    {
        moverseDe = true;
        particula.Play();
        audioPropulsor.Play();
    }
    public void PropulsorIz()
    {
        moverseIz = true;
        particula.Play();
        audioPropulsor.Play();
    }

    public void PropulsorDeEnd()
    {
        moverseDe = false;
        particula.Stop();
        audioPropulsor.Stop();
    }
    public void PropulsorIzEnd()
    {
        moverseIz = false;
        particula.Stop();
        audioPropulsor.Stop();
    }
}
