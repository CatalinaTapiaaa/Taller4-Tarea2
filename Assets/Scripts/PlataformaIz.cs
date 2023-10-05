using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaIz : MonoBehaviour
{
    public bool playerCollision;

    private void Update()
    {
        if (playerCollision)
        {
            gameObject.tag = "Suelo";
        }       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollision = true;
        }
    }
}
