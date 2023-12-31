using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [Header("Texto")]
    public TextMeshProUGUI punInterface;

    [Header("Paneles")]
    public GameObject panelPausa;

    [Header("Puntuacion")]
    public GameObject componente;
    public Controlador controlador;

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        punInterface.text = controlador.puntuacion.ToString("LEVEL 0");
    }

    public void Pausar()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void VolverMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void VolverGame()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
    }
}
