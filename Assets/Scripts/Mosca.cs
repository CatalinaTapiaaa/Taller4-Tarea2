using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosca : MonoBehaviour
{
    bool muerte;

    private void Update()
    {
        if (muerte)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lengua"))
        {
            muerte = true;
        }
    }    
}
