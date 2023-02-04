using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RootRenderer))]

public class Root : MonoBehaviour
{
	public List<rootPoint> points;
	public float startThickness;
	public float endThickness;
	private RootRenderer r;
	public Root(){
		points = new List<rootPoint>();
		//add first point
		points.Add(new rootPoint());
	}

	public void Grow(Vector2 direction) //extends the root into a direction
	{
		//Debug.Log("Growing! from: ");
		//Debug.Log(points[points.Count - 1].position.ToString());
		Vector2 newPointPosition = points[points.Count - 1].position + direction;
		points.Add(new rootPoint(newPointPosition));
		//Debug.Log("current line:");
		/*
		foreach (rootPoint rp in points)
		{
			Debug.Log(rp.position.ToString());
		}
		*/
		//re-fresh root visuals
		r.RefreshRootVisuals(points);
	}
    // Start is called before the first frame update
    void Start()
    {
	    r = GetComponent<RootRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
