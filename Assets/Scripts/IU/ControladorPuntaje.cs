using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntaje : MonoBehaviour
{
	[Header("Score")]
	public int puntuacion;
	public int changeEnemy;
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

	private void Load()
	{
		if (PlayerPrefs.HasKey("Puntuacion"))
		{
			puntuacion = PlayerPrefs.GetInt("Puntuacion");
		}
		if (PlayerPrefs.HasKey("ChangeEnemy"))
		{
			changeEnemy = PlayerPrefs.GetInt("ChangeEnemy");
		}
	}
}
