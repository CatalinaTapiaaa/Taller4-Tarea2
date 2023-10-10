using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool muerte;
    public GameObject lineRenderer;

    void Update()
    {
        if (muerte)
        {
            Destroy(gameObject);
            Destroy(lineRenderer);
        }
    }
}
