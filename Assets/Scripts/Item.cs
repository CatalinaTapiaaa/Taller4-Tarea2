﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerExperiment
{
    public class Item : Otro
    {
        bool UseInefficientCode;
        int nCheckpoints;
        int nCurves;
        float subTotal = 0f;

        private void Update()
        {
            GetBezier(out myPosition, Pivots, mTime);
            item.transform.position = myPosition;
        }

        public override void GetBezier(out Vector3 pos, List<GameObject> Checkpoints, float time)
        {
            nCheckpoints = Checkpoints.Count;
            nCurves = nCheckpoints / (3 - 1);

            if (subTotal == 0f)
            {
                subTotal = 1f / nCurves;
            }
            
            float localPercentage = GetLocalPercentage(time);
            int localStartPoint = GetLocalStart(time);

            int index0 = localStartPoint;
            int index1 = localStartPoint + 1;
            int index2 = localStartPoint + 2;

            if (index0 < nCheckpoints - 2)
            {
                Vector3 p0 = Checkpoints[index0].transform.position;
                Vector3 p1 = Checkpoints[index1].transform.position;
                Vector3 p2 = Checkpoints[index2].transform.position;

                QuadraticBezierEquation.GetCurve(out pos, p0, p1, p2, localPercentage, UseInefficientCode);
            }
            else
            {
                Vector3 start = Checkpoints[index0].transform.position;
                Vector3 end = Checkpoints[nCheckpoints - 1].transform.position;

                pos = Vector3.Lerp(start, end, localPercentage);
            }
        }

        float GetLocalPercentage(float time)
        {
            float remainder = time % subTotal; 
            float percentage = remainder / subTotal;
            return percentage;
        }

        int GetLocalStart(float time)
        {
            int n = (int)(time / subTotal);

            int index = n * (3 - 1);

            return index;
        }
    }
}