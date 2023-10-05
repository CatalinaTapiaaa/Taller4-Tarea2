using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
	public Animator ani;
	[Space]
	public bool reiniciar;
	public bool volverTitulo;
	public float tiempo;
	float time;

    private void Start()
    {
		StartCoroutine(AnimacionCerrar());
	}

	void Update()
    {
		if (reiniciar)
        {
			time += Time.deltaTime;

			if (time >= tiempo)
            {
				StartCoroutine(AnimacionAbrir());
			}
		}
		if (volverTitulo)
        {
			StartCoroutine(AnimacionAbrirTitulo());
		}
	}

    private IEnumerator AnimacionAbrir()
	{		
		ani.SetBool("Abrir", true);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(2);
	}
	private IEnumerator AnimacionCerrar()
	{
		ani.SetBool("Cerrar", true);
		yield return new WaitForSeconds(1);
		ani.SetBool("Cerrar", false);
	}
	private IEnumerator AnimacionAbrirTitulo()
	{
		ani.SetBool("Abrir", true);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(0);
	}
}
