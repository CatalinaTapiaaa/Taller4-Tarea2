using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform[] puntos;
    public Animator ani;
    public GameObject panelGameOver;
    public Spawn spawn;
    public Player player;
    public Linea line;
    public float aniMuerte;
    public bool muerte;

    void Start()
    {
        line.SetUpLine(puntos);
    }

    void Update()
    {
        if (muerte)
        {
            StartCoroutine(GameOver(aniMuerte));
        }
    }


    IEnumerator GameOver(float seconds)
    {
        spawn.activarBueno = false;
        spawn.activarMalo = false;

        player.gameOver = true;
        ani.SetBool("Derrota", true);
        //tembrar pantalla
        //rana roja y ojos en x_x
        yield return new WaitForSeconds(seconds);
        panelGameOver.SetActive(true);
    }
}
