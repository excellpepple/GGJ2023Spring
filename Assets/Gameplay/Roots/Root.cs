using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RootRenderer))]

public class Root : MonoBehaviour
{
	public List<rootPoint> points;
	private RootRenderer r;
	public Root(){
		points = new List<rootPoint>();
		//add first point
		points.Add(new rootPoint());
	}

	public rootPoint Grow(Vector2 direction) //extends the root into a direction
	{
		Vector2 newPointPosition = points[points.Count - 1].position + direction;
		points.Add(new rootPoint(newPointPosition));

		//refresh root visuals
		if (r)
		{
			r.RefreshRootVisuals(points);
		}

		return points[points.Count - 1]; //return the newly created point
	}
	
    // Start is called before the first frame update
    void Start()
    {
	    r = GetComponent<RootRenderer>();
    }
}
