using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemy : MonoBehaviour
{
    [SerializeField] private AudioClip audioAparicion;
    public GameObject enemy;
    public GameObject trampa;
    [Space]
    public Transform[] pivotEnemy;
    public List<GameObject> enemyOrTrampa = new List<GameObject>();
    public GameObject botones; 
    [Space]
    public bool reiniciar;
    public float tiempoInicial;
    public float tiempoAni;
    [Header("Puntaje")]
    public GameObject componente;
    public ControladorPuntaje controlPuntaje;

    float tiempo;
    float tiempo1;
    int current;

    void Start()
    {
        componente = GameObject.Find("CONTROLADOR PUNTAJE");
        controlPuntaje = componente.GetComponent<ControladorPuntaje>();
        reiniciar = true;
        if (controlPuntaje.changeEnemy == 1)
        {
            enemyOrTrampa.Add(enemy);
        }
        if (controlPuntaje.changeEnemy == 2)
        {
            enemyOrTrampa.Add(trampa);
        }
    }

    void Update()
    {       

        if (reiniciar)
        {
            tiempo1 += Time.deltaTime;
            if (tiempo1 >= tiempoInicial)
            {
                tiempo += Time.deltaTime;
                botones.SetActive(false);

                if (tiempo >= tiempoAni)
                {
                    ControlSonidos.Instance.EjecutarSonido(audioAparicion);
                    int aleatorio = Random.Range(0, enemyOrTrampa.Count);
                    Instantiate(enemyOrTrampa[aleatorio], pivotEnemy[current].position, Quaternion.identity);
                    tiempo = 0;
                    current++;
                }
                if (current == 4)
                {
                    current++;
                }
                if (current == 5)
                {
                    reiniciar = false;
                    botones.SetActive(true);
                }
            }            
        }
    }
}
