using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayOrTutorial : MonoBehaviour
{
	[Header("Score")]
	public int num;
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
		if (PlayerPrefs.HasKey("Num"))
		{
			num = PlayerPrefs.GetInt("Num");
		}		
	}
}
