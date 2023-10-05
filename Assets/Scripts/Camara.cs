using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Camera cam;
    public Player player;
    public Meta meta;
    public GameObject panelSatisfaccion;
    public PlataformaDe plataformaDe;

    [Header("Camara Lenta")]
    public Transform posicionZoom;
    public Transform posicionDefaut;
    private float velocidadPos = 20;
    public float acercar;
    public float posicionNormal;
    public float velocidad;

    [Header("Muerte")]
    public bool temblor;
    private float shakeDuracion = 0.1f;
    private float shakeAmount = 0.2f;

    void Update()
    {
        if (plataformaDe.camaraLenta)
        {
            meta.activar = true;
            transform.position = Vector3.MoveTowards(transform.position, posicionZoom.position, velocidadPos);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, acercar, velocidad);
            panelSatisfaccion.SetActive(true);
        }

        if (player.muerte)
        {
            Muerte();
            player.muerte = false;
        }
    }

    private IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;
        while (elapsed < shakeDuracion)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;
            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
    public void Muerte()
    {
        StartCoroutine(Shake());
    }
}
