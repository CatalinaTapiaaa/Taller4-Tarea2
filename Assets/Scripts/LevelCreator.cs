using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Transform[] pivot;
    public Transform pivotDe;
    public Transform pivotIz;
    public GameObject pincho;
    public GameObject moscas;
    [Space]
    public BarraProgreso barraProgreso;
    public Player player;
    public GameObject componente;
    public Controlador controlador;
    [Space]
    public bool crearNivel;
    public bool cerrarNivel;
    [Space]
    public float posicion;
    public float velocidad; 

    List<int> usedPivots = new List<int>();
    bool abrir, cerrar, spawn;
    int cantidadPinchos, cantidadMoscas;

    void Start()
    {
        cerrarNivel = true; 
    }

    void Update()
    {
        componente = GameObject.Find("CONTROLADOR");
        controlador = componente.GetComponent<Controlador>();

        if (crearNivel)
        {
            if (controlador.puntuacion == 0)
            {
                cantidadMoscas = 1;
                cantidadPinchos = 0;
            }
            if (controlador.puntuacion == 5)
            {
                cantidadMoscas = 2;
                cantidadPinchos = 2;
            }
            if (controlador.puntuacion == 10)
            {
                cantidadMoscas = 3;
                cantidadPinchos = 4;
            }
            if (controlador.puntuacion == 15)
            {
                cantidadMoscas = 4;
                cantidadPinchos = 6;
            }
           
            abrir = true;
            spawn = true;
            player.stop = true;
            barraProgreso.activar = true;
            barraProgreso.todasMoscas = true;
            crearNivel = false;
        }
        if (spawn)
        {
            SpawnObj();
            spawn = false;
        }
        if (cerrarNivel)
        {
            cerrar = true;
            player.stop = true;
            cerrarNivel = false;
        }

        if (abrir)
        {
            Vector3 abrirDe = new Vector2(-posicion, pivotDe.position.y);
            Vector3 abrirIz = new Vector2(posicion, pivotIz.position.y);

            pivotDe.position = Vector3.MoveTowards(pivotDe.position, abrirDe, velocidad * Time.deltaTime);
            pivotIz.position = Vector3.MoveTowards(pivotIz.position, abrirIz, velocidad * Time.deltaTime);

            if (pivotDe.position == abrirDe)
            {
                abrir = false;
                player.stop = false;
                player.reiniciar = true;
            }
        }
        if (cerrar)
        {
            barraProgreso.activar = false;
            Vector3 cerrarDe = new Vector2(-2.5f, pivotDe.position.y);
            Vector3 cerrarIz = new Vector2(2.5f, pivotIz.position.y);

            pivotDe.position = Vector3.MoveTowards(pivotDe.position, cerrarDe, velocidad * Time.deltaTime);
            pivotIz.position = Vector3.MoveTowards(pivotIz.position, cerrarIz, velocidad * Time.deltaTime);

            if (pivotDe.position == cerrarDe)
            {
                crearNivel = true;
                Destruir();
                cerrar = false;
            }
        }      
    }

    void Spawn(GameObject prefab, int amount)
    {       
        for (int i = 0; i < amount; i++)
        {
            int aleatorio = 0;
            do
            {
                aleatorio = Random.Range(0, pivot.Length);
            } while (usedPivots.Contains(aleatorio));

            usedPivots.Add(aleatorio);

            Vector3 spawnPosition = pivot[aleatorio].position;
            Quaternion spawnRotation = pivot[aleatorio].rotation;
            GameObject newObj = Instantiate(prefab, spawnPosition, spawnRotation);
            newObj.transform.SetParent(pivot[aleatorio]);
        }
    }
    void Destruir()
    {
        foreach (Transform pivotObject in pivot)
        {
            foreach (Transform child in pivotObject)
            {
                Destroy(child.gameObject);
            }
        }

        usedPivots.Clear();
    }
    void SpawnObj()
    {
        Spawn(pincho, cantidadPinchos);
        Spawn(moscas, cantidadMoscas);
    }
}
