using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    public PlayerManager playerManager;
    public Player player;
    public Puntaje pun;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemBlanco"))
        {
            player.atacar = false;
            pun.sumarPuntos = true;
        }
        if (collision.gameObject.CompareTag("ItemRojo"))
        {
            playerManager.muerte = true;
        }

        if (collision.gameObject.CompareTag("Pared"))
        {
            player.atacar = false;
        }       
    }
}
