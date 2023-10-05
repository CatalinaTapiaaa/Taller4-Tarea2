using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TituloUI : MonoBehaviour
{
    public Animator ani;
    public GameObject panelReiniciar;

    [Header("Gameplay o Tutorial")]
    public GameObject componente;
    public GameplayOrTutorial controlador;
    [Space]
    public GameObject botonGameplay;
    public GameObject botonTutorial;

    [Header("Gameplay o Tutorial")]
    public GameObject componentePuntaje;
    public ControladorPuntaje controladorPuntaje;

    private void Start()
    {
        StartCoroutine(AnimacionCerrar());
    }

    private void Update()
    {
        componente = GameObject.Find("GAMEPLAY OR TURORIAL");
        controlador = componente.GetComponent<GameplayOrTutorial>();

        componentePuntaje = GameObject.Find("CONTROLADOR PUNTAJE");
        controladorPuntaje = componentePuntaje.GetComponent<ControladorPuntaje>();

        if (controlador.num == 0)
        {
            botonGameplay.SetActive(false);
            botonTutorial.SetActive(true);
        }
        else if (controlador.num > 0)
        {
            botonGameplay.SetActive(true);
            botonTutorial.SetActive(false);
        }
    }
    public void Gameplay()
    {
        Time.timeScale = 1;
        StartCoroutine(AnimacionAbrirGameplay());
        botonGameplay.SetActive(false);
    }
    public void Turorial()
    {
        Time.timeScale = 1;
        controlador.num += 1;
        StartCoroutine(AnimacionAbrirTutorial());
        botonTutorial.SetActive(false);
    }
    public void Reiniciar()
    {
        panelReiniciar.SetActive(true);
    }
    public void Si()
    {
        panelReiniciar.SetActive(false);
        controlador.num = 0;
        controladorPuntaje.puntuacion = 0;
        controladorPuntaje.changeEnemy = 0;
    }
    public void No()
    {
        panelReiniciar.SetActive(false);
    }

    public void Creditos()
    {
        Time.timeScale = 1;
        StartCoroutine(AnimacionAbrirCreditos());
    }

    private IEnumerator AnimacionAbrirGameplay()
    {
        ani.SetBool("Abrir", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
    private IEnumerator AnimacionAbrirTutorial()
    {
        ani.SetBool("Abrir", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    private IEnumerator AnimacionAbrirCreditos()
    {
        ani.SetBool("Abrir", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }

    private IEnumerator AnimacionCerrar()
    {
        ani.SetBool("Cerrar", true);
        yield return new WaitForSeconds(1);
        ani.SetBool("Cerrar", false);
    }
}
