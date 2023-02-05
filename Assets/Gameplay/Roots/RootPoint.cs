using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class rootPoint{
	public Vector2 position;
	public rootPoint()
	{
		position = new Vector2();
		connectedRoots = new List<Root>();
	}
	public rootPoint(Vector2 p)
	{
		position = p;
		connectedRoots = new List<Root>();
	}
	public List<Root> connectedRoots;
}