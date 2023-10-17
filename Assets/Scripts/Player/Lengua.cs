using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    public Player player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemBlanco"))
        {
            player.atacar = false;
        }
        if (collision.gameObject.CompareTag("ItemRojo"))
        {

        }

        if (collision.gameObject.CompareTag("Pared"))
        {
            player.atacar = false;
        }       
    }
}
