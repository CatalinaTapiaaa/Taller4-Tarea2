using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [Header("Componentes")]
    public MovimientoPlayer movimientoPlayer;

    [Header("Stats")]
    public float rayDistancia;
    public float tiempoEspera;
    public float tiempo;

    bool playerColisiona, desactivarPlataforma;

    [Header("Puntaje")]
    public GameObject componenteScore;
    public ControladorPuntaje controladorPuntaje;

    void Update()
    {
        componenteScore = GameObject.Find("CONTROLADOR PUNTAJE");
        controladorPuntaje = componenteScore.GetComponent<ControladorPuntaje>();

        RaycastHit hit;

        if (!desactivarPlataforma)
        {
            if (Physics.Raycast(transform.position, transform.up, out hit, rayDistancia))
            {
                if (hit.transform.tag == "Player")
                {
                    tiempo += Time.deltaTime;
                    if (playerColisiona)
                    {
                        if (tiempo >= tiempoEspera)
                        {
                            hit.transform.gameObject.GetComponent<EnergiaPlayer>().reponerEnergia = true;
                            controladorPuntaje.puntuacion += 1;
                            desactivarPlataforma = true;
                            movimientoPlayer.sinEnergia = true;
                            movimientoPlayer.impulsoPlataforma = true;
                        }
                        else
                        {
                            hit.transform.gameObject.GetComponent<Player>().muerte = true;
                        }
                    }

                }
            }
            else
            {
                tiempo = 0;
            }
        }     
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.up * rayDistancia);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerColisiona = true;
        }
    } 
}
