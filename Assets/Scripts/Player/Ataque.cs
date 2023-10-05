using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            player.muerte = true;
        }
    }
}
