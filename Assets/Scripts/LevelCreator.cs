using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Player player;
    public int cantidadPinchos, cantidadMoscas;
    [Space]
    public Transform[] pivotDe;
    public Transform[] pivotIz;
    public Transform[] pivot;
    [Space]
    public GameObject pincho;
    public GameObject moscas;
    [Header("Transicion")]
    public float posicion;
    public float velocidad;
    public float tiempoAni;
    public bool crearNivel, cerrarNivel;

    [Header("Puntuacion")]
    public GameObject componente;
    public Controlador controlador;


    List<int> usedPivots = new List<int>();
    float[] inicioDe, inicioIz;
    float t1, t2, t3, t4;
    bool abrir, cerrar, spawn;

    void Start()
    {
        crearNivel = true;

        inicioDe = new float[pivotDe.Length];
        inicioIz = new float[pivotIz.Length];

        for (int i = 0; i < pivotDe.Length; i++)
        {
            inicioDe[i] = pivotDe[i].position.x;
            inicioIz[i] = pivotIz[i].position.x;
        }
    }

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();
        GameObject[] moscas = GameObject.FindGameObjectsWithTag("Mosca");

        if (spawn)
        {
            Spawn();
            spawn = false;
        }

        if (crearNivel)
        {
            player.stop = true;
            abrir = true;
            cerrar = false;
            spawn = true;
            crearNivel = false;
        }
        if (cerrarNivel)
        {
            player.stop = true;
            abrir = false;
            cerrar = true;
            cerrarNivel = false;
        }

        if (abrir)
        {
            t1 += Time.deltaTime;
            t2 = 0;
            t3 = 0;

            for (int i = 0; i < pivotDe.Length; i++)
            {
                float tiempoObjetivo = tiempoAni * (i + 1);

                if (t1 >= tiempoObjetivo)
                {
                    Vector2 abrirDe = new Vector2(-posicion, pivotDe[i].position.y);
                    Vector2 abrirIz = new Vector2(posicion, pivotIz[i].position.y);

                    pivotDe[i].position = Vector3.MoveTowards(pivotDe[i].position, abrirDe, velocidad * Time.deltaTime);
                    pivotIz[i].position = Vector3.MoveTowards(pivotIz[i].position, abrirIz, velocidad * Time.deltaTime);
                }
                if (i == pivotDe.Length - 1)
                {
                    t4 += Time.deltaTime;
                    if (t4 >= tiempoAni)
                    {
                        cerrar = false;
                        player.stop = false;
                    }
                }
            }            
        }
        if (cerrar)
        {
            t2 += Time.deltaTime;
            t1 = 0;
            t4 = 0;

            for (int i = 0; i < pivotDe.Length; i++)
            {
                float tiempoObjetivo = tiempoAni * (i + 1);

                if (t2 >= tiempoObjetivo)
                {
                    Vector3 cerrarDe = new Vector2(inicioDe[i], pivotDe[i].position.y);
                    Vector3 cerrarIz = new Vector2(inicioIz[i], pivotIz[i].position.y);

                    pivotDe[i].position = Vector3.MoveTowards(pivotDe[i].position, cerrarDe, velocidad * Time.deltaTime);
                    pivotIz[i].position = Vector3.MoveTowards(pivotIz[i].position, cerrarIz, velocidad * Time.deltaTime);

                    if (pivotIz[i].position == cerrarIz)
                    {
                        foreach (Transform child in pivotIz[i])
                        {
                            if (child.position == cerrarIz)
                            {
                                Destroy(child.gameObject);
                            }
                        }
                        foreach (Transform child in pivotDe[i])
                        {
                            if (child.position == cerrarDe)
                            {
                                Destroy(child.gameObject);
                            }
                        }
                    }
                    if (i == pivotDe.Length - 1)
                    {
                        t3 += Time.deltaTime;
                        if (t3 >= tiempoAni)
                        {
                            cerrar = false;
                            player.stop = false;
                        }
                    }
                }                  
            }            
        }        
    }

    void Spawn()
    {
        for (int i = 0; i < cantidadPinchos; i++)
        {
            int aleatorio;
            do
            {
                aleatorio = Random.Range(0, pivot.Length);
            } while (usedPivots.Contains(aleatorio));

            usedPivots.Add(aleatorio);

            Vector3 spawnPosition = pivot[aleatorio].position;
            Quaternion spawnRotation = pivot[aleatorio].rotation;
            GameObject newPincho = Instantiate(pincho, spawnPosition, spawnRotation);
            newPincho.transform.SetParent(pivot[aleatorio]);
        }

        for (int i = 0; i < cantidadMoscas; i++)
        {
            int aleatorio;
            do
            {
                aleatorio = Random.Range(0, pivot.Length);
            } while (usedPivots.Contains(aleatorio));

            usedPivots.Add(aleatorio);

            Vector3 spawnPosition = pivot[aleatorio].position;
            Quaternion spawnRotation = pivot[aleatorio].rotation;
            GameObject newMosca = Instantiate(moscas, spawnPosition, spawnRotation);
            newMosca.transform.SetParent(pivot[aleatorio]);
        }
    }
}
