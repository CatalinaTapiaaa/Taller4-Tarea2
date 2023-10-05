using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoVictoria : MonoBehaviour
{
    [Header("Puntaje")]
    public GameObject componenteScore;
    public ControladorPuntaje controladorPuntaje;
    public TextMeshProUGUI textoAntes;
    public TextMeshProUGUI textoDespues;

    private void Start()
    {
        componenteScore = GameObject.Find("CONTROLADOR PUNTAJE");
        controladorPuntaje = componenteScore.GetComponent<ControladorPuntaje>();

        int a = controladorPuntaje.puntuacion;
        int puntajeActual = a += 1;
        textoAntes.text = controladorPuntaje.puntuacion.ToString("0");
        textoDespues.text = a.ToString("0");
    } 
}
