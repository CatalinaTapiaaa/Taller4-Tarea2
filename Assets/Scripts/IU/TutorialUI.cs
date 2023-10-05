using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    public Animator ani;
    public bool pasarGameplay;

    private void Start()
    {
        StartCoroutine(AnimacionCerrar());
    }

    private void Update()
    {
        if (pasarGameplay)
        {
            StartCoroutine(AnimacionAbrir());
        }
    }

    private IEnumerator AnimacionCerrar()
    {
        ani.SetBool("Cerrar", true);
        yield return new WaitForSeconds(1);
        ani.SetBool("Cerrar", false);
    }
    private IEnumerator AnimacionAbrir()
    {
        ani.SetBool("Abrir", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
