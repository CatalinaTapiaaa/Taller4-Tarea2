using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public int puntuacion;
    private static bool created;

    void Start()
    {
        if (created)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        created = true;
    }

    void LoadScore()
    {
        if (PlayerPrefs.HasKey("Puntuacion"))
        {
            puntuacion = PlayerPrefs.GetInt("Puntuacion");
        }
    }
}
