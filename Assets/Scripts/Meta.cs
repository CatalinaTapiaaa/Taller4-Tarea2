using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meta : MonoBehaviour
{
    [Header("Componentes")]
    public Reiniciar reiniciar;
    public Image barra;
    public float rellenarBarra;
    public int aleatorio;
    [Space]
    public float tiempoDespues;
    public GameObject panelEnemy;
    public GameObject panelTrampa;

    float tiempo;
    public bool playerTrigger, playerCollision;
    float cargaMax = 100;
    public bool rellenarIz, rellenarDe;
    public bool activar;
    //llenar toda la barra con energia, el jugador la llena volando la nave en el trigger
    float t;

    private void Start()
    {
        aleatorio = Random.Range(1, 3);
    }

    void Update()
    {
        if (activar)
        {
            if (rellenarIz)
            {
                tiempo += rellenarBarra * Time.deltaTime;
            }
            if (rellenarDe)
            {
                tiempo += rellenarBarra * Time.deltaTime;
            }
        }

        if (playerTrigger)
        {
            if (tiempo >= cargaMax)
            {
                if (playerCollision)
                {
                    t += Time.deltaTime;
                    if (t >= tiempoDespues)
                    {
                        if (aleatorio == 1)
                        {
                            panelEnemy.SetActive(true);
                        }
                        if (aleatorio == 2)
                        {
                            panelTrampa.SetActive(true);
                        }
                    }             
                }
            }
            else
            {
                if (playerCollision)
                {
                    t += Time.deltaTime;
                    if (t >= tiempoDespues)
                    {
                        reiniciar.reiniciar = true;
                    }
                }
            }
        }

        barra.fillAmount = tiempo / cargaMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollision = true;
        }
    }

    public void RellenarIz()
    {
        rellenarIz = true;
    }
    public void RellenarIzEnd()
    {
        rellenarIz = false;
    }
    public void RellenarDe()
    {
        rellenarDe = true;
    }
    public void RellenarDeEnd()
    {
        rellenarDe = false;
    }
}
