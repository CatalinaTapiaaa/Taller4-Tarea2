using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip audioExplosion;
    [Space]
    public bool muerte, noControl;
    [Space]
    public GameObject controles;
    public Meta meta;
    public Reiniciar reiniciar;
    public GameObject explocion;
    public Transform posicionExplocion;

    void Update()
    {
        if (muerte)
        {
            ControlSonidos.Instance.EjecutarSonido(audioExplosion);
            noControl = true;
            Instantiate(explocion, posicionExplocion.position, Quaternion.identity);
            Destroy(gameObject);
            reiniciar.reiniciar = true;
        }
        if (noControl)
        {
            controles.SetActive(false);
            meta.rellenarIz = false;
            meta.rellenarDe = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            muerte = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            muerte = true;
        }
    }

}
