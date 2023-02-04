using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RootRenderer : MonoBehaviour
{
   public LineRenderer lr;

   private void Start()
   {
       lr = GetComponent<LineRenderer>();
   }

   public void RefreshRootVisuals(List<rootPoint> l)
   {
	   Vector3[] newPoints = new Vector3[l.Count];
	   int i = 0;
       while (i < l.Count)
       {
	       newPoints[i] = new Vector3(l[i].position.x, l[i].position.y, 0.0f);
	       i++;
       }

       lr.positionCount = newPoints.Length;
       lr.SetPositions(newPoints);
   }
}
