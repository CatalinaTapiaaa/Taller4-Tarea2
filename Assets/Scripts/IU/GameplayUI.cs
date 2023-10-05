using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    public GameObject botonEnemy, botonTrampa;
    public GameObject panelBotonPausa;
    public GameObject panelPausa;
    public Reiniciar reiniciar;

    [Header("Puntaje")]
    public GameObject componente;
    public ControladorPuntaje controlPuntaje;

    private void Update()
    {
        componente = GameObject.Find("CONTROLADOR PUNTAJE");
        controlPuntaje = componente.GetComponent<ControladorPuntaje>();
    }

    public void Pausar()
    {
        Time.timeScale = 0;
        panelBotonPausa.SetActive(false);
        panelPausa.SetActive(true);
    }
    public void Reanudar()
    {
        Time.timeScale = 1;
        panelBotonPausa.SetActive(true);
        panelPausa.SetActive(false);
    }
    public void Menu()
    {
        reiniciar.volverTitulo = true;
        Time.timeScale = 1;
    }

    public void BotonEnemy()
    {
        reiniciar.reiniciar = true;
        controlPuntaje.changeEnemy = 1;
        controlPuntaje.puntuacion += 1;
        botonEnemy.SetActive(false);
    }
    public void BotonTrampa()
    {
        reiniciar.reiniciar = true;
        controlPuntaje.changeEnemy = 2;
        controlPuntaje.puntuacion += 1;
        botonTrampa.SetActive(false);
    }   
}
