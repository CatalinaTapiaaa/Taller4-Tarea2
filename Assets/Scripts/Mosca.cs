using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosca : MonoBehaviour
{
    public bool muerte ;
  

    void Update()
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
