using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public Player player;
    public Animator ani;
    public Image barraProgreso;
    public float tiempoAni;
    public float maxBarra;
    public bool sumarPuntos;
    [Space]
    [Header("Puntuacion")]
    public GameObject componente;
    public Controlador controlador;

    float t, current;

    void Start()
    {
        current = 1;
    }

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        if (sumarPuntos)
        {
            t += Time.deltaTime;

            if (t >= current)
            {
                current += 1;
                sumarPuntos = false;
            }
        }

        if (current == maxBarra)
        {
            t = 0;
            StartCoroutine(NuevoNivel(tiempoAni));
            controlador.puntuacion += 1;
            current = 0;
        }

        barraProgreso.fillAmount = t / maxBarra;
    }

    IEnumerator NuevoNivel(float seconds)
    {
        player.stop = true;

        ani.SetBool("Victoria",true);
        //eructar
        yield return new WaitForSeconds(seconds);
        player.stop = false;
        ani.SetBool("Victoria", false);
    }

    IEnumerator NuevaRana(float seconds)
    {
        player.stop = true;

        ani.SetBool("Cambio", true);
        //eructar
        yield return new WaitForSeconds(seconds);

        int aleatorio = Random.Range(1, 4); // escenas donde hay ranas 4, no repetie la misma
        SceneManager.LoadScene(aleatorio);
    }
}
