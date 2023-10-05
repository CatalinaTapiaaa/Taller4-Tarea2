using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip audioMuerte;
    public Animator ani;

    void Start()
    {
        StartCoroutine(Animacion());
    }

    private IEnumerator Animacion()
    {
        ani.SetBool("Move", true);
        yield return new WaitForSeconds(1);
        ani.SetBool("Move", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAtaque"))
        {
            ControlSonidos.Instance.EjecutarSonido(audioMuerte);
            StartCoroutine(Muerte());
        }
    }
    private IEnumerator Muerte()
    {
        ani.SetBool("Muerte", true);
        yield return new WaitForSeconds(0.30f);
        Destroy(gameObject);
    }
}
