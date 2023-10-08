using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
	[Header("Puntuacion")]
	public int puntuacion;
	public int puntuacionMaxima;
	private static bool created;


	public void Start()
	{
		if (created)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
		created = true;
	}

    void Update()
    {
        if (puntuacion > puntuacionMaxima)
        {
			puntuacionMaxima = puntuacion;
		}
    }

    private void Load()
	{
		if (PlayerPrefs.HasKey("Puntuacion"))
		{
			puntuacion = PlayerPrefs.GetInt("Puntuacion");
		}
		if (PlayerPrefs.HasKey("PuntuacionMaxima"))
		{
			puntuacionMaxima = PlayerPrefs.GetInt("PuntuacionMaxima");
		}
	}
}
