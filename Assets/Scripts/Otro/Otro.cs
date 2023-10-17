using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerExperiment
{
    public abstract class Otro : MonoBehaviour
    {
        public GameObject item;
        public GameObject pivotComienzo;
        public float velocidad;
        public List<GameObject> Pivots = new List<GameObject>();

        GameObject[] pivotsMedio, pivotsDe, pivotsIz;
        protected float mTime;
        protected Vector3 myPosition;
        bool AutoTime = true;
        int aleatorioMedio, aleatorioDe, aleatorioIz;
        bool de, iz;

        public abstract void GetBezier(out Vector3 pos, List<GameObject> Checkpoints, float time);

        void Awake()
        {
            pivotsMedio = GameObject.FindGameObjectsWithTag("Pivots");
            pivotsDe = GameObject.FindGameObjectsWithTag("De");
            pivotsIz = GameObject.FindGameObjectsWithTag("Iz");

            aleatorioMedio = Random.Range(5, pivotsMedio.Length);
            aleatorioDe = Random.Range(0, pivotsDe.Length);
            aleatorioIz = Random.Range(0, pivotsIz.Length);

            Pivots.Add(pivotComienzo);

            if (pivotsMedio.Length >= aleatorioMedio)
            {
                for (int i = 0; i < aleatorioMedio; i++)
                {
                    Pivots.Add(pivotsMedio[i]);
                }
            }

            if (item.transform.position.x < 0)
            {
                iz = true;

                for (int i = 0; i < 1; i++)
                {
                    Pivots.Add(pivotsDe[aleatorioDe]);
                }
            }
            if (item.transform.position.x > 0)
            {
                de = true;

                for (int i = 0; i < 1; i++)
                {
                    Pivots.Add(pivotsIz[aleatorioIz]);
                }
            }
        }

        void Start()
        {
            StartCoroutine(Mover());
        }

        IEnumerator Mover()
        {
            while (true)
            {
                if (AutoTime)
                {
                    mTime += Time.deltaTime * velocidad;

                    if (velocidad <= 0f)
                    {
                        velocidad = 0.1f;
                    }

                    if (mTime >= 1f)
                    {
                        mTime = 0f;
                    }
                }

                yield return null;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (de)
            {
                if (collision.gameObject.CompareTag("Iz"))
                {
                    Destroy(item);
                    Destroy(pivotComienzo);
                }
            }
            if (iz)
            {
                if (collision.gameObject.CompareTag("De"))
                {
                    Destroy(item);
                    Destroy(pivotComienzo);
                }
            }

            if (collision.gameObject.CompareTag("Lengua"))
            {
                Destroy(item);
                Destroy(pivotComienzo);
            }
        }
    }
}