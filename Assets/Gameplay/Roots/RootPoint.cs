using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootPoint{
	public Vector2 position;
	public rootPoint()
	{
		position = new Vector2();
	}
	public rootPoint(Vector2 p)
	{
		position = p;
	}
	public List<Root> connectedRoots;
}