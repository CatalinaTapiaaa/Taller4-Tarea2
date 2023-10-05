using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPuntaje : MonoBehaviour
{
    [Header("Puntaje")]
    public GameObject componenteScore;
    public ControladorPuntaje controladorPuntaje;
    public TextMeshPro puntuacionTexto; 

    void Update()
    {
        componenteScore = GameObject.Find("CONTROLADOR PUNTAJE");
        controladorPuntaje = componenteScore.GetComponent<ControladorPuntaje>();

        puntuacionTexto.text = controladorPuntaje.puntuacion.ToString("0");
    }
}
