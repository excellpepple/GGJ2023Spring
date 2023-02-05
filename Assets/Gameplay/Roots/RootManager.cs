using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
	[Header("References")]
	public GameObject RootType; //what to instantiate when roots grow

	[Header("Gameplay Variables")]
	[Tooltip("cooldown in seconds how often roots grow")]
	public float growCooldown = 0.25f;
	[Tooltip("how far roots grow every time they grow")]
	public float growDistance = 3.0f;
	
	[Header("Internal")]
	public Root baseRoot; //resisted the temptation to call this RootRoot
	public Root currentRoot; //the root the player is modifying at the moment
	public rootPoint currentPoint; //when the root grows, that should be the last point
	public int currentPointID; //the ID of te currently selected point (so we don't have to find it in the list)
	private RootInputVisualizer visualizer;
	
	//timing
	public float lastGrowEvent;

	void Start()
	{
		visualizer = GetComponentInChildren<RootInputVisualizer>();
		lastGrowEvent = Time.time;
	    if (RootType)
	    {
		    baseRoot = Instantiate(RootType, transform).GetComponent<Root>();
		    baseRoot.isBase = true;
		    currentRoot = baseRoot;
	    }
	    else
	    {
		    Debug.LogError("Root prefab hasn't been assigned to RootManager ");
	    }
    }

    public Vector3 Grow(Vector2 direction)
    {
	    if (Time.time - lastGrowEvent > growCooldown)
	    {
		    //we only grow the current root if we selected the end, otherwise we branch
		    if (currentPointID == currentRoot.points.Count - 1)
		    {
			    //extend root
			    Extend(direction);
		    }
		    else
		    {
			    //create new root and then grow that
			    Branch(currentPoint, direction);
		    }
		    visualizer.setRootPoint(currentPoint);
		    lastGrowEvent = Time.time;
	    }
	    return currentPoint.position;
    }
    
	//sets the current point to a different one, up or down the root
    public void Traverse(int direction)
    {
	    //if we are at beginning ot root, going back, traverse to parent
	    if (direction < 0 && currentPointID == 0)
	    {
		    if (currentRoot.isBase == true)
		    {
			    currentPoint = currentRoot.attachmentPoint;
			    currentRoot = currentRoot.gameObject.transform.parent.GetComponent<Root>();
			    currentPointID = currentRoot.points.IndexOf(currentPoint);
		    }
		    else
		    {
			    Debug.Log("reached very top");
		    }
	    }
	    else
	    {
		    currentPointID = Mathf.Clamp(currentPointID + direction, 0, currentRoot.points.Count - 1);
		    currentPoint = currentRoot.points[currentPointID];
	    }
	    visualizer.setRootPoint(currentPoint);
    }

    public void Branch(rootPoint p, Vector2 direction)
    {
	    Vector3 newPos = currentPoint.position;
	    //create a new root at the position of the current RootPoint
	    currentPoint.connectedRoots.Add(Instantiate(
			    RootType,
			    newPos,
			    Quaternion.identity,
			    currentRoot.transform
		    ).GetComponent<Root>());
	    //add what was just added
	    currentRoot = currentPoint.connectedRoots[currentPoint.connectedRoots.Count - 1];
	    currentRoot.attachmentPoint = currentPoint;
	    //workaround: need to set position after instantiating (bug IN-31177)
	    currentRoot.transform.position = newPos;
	    //set the position of the first point to the same
	    currentPoint = currentRoot.points[0];
	    currentPoint.position = newPos;
	    Extend(direction);
    }

    public void Extend(Vector2 direction)
    {
	    Vector2 n = direction.normalized;
	    currentPoint = currentRoot.Grow(n * growDistance);
	    currentPointID = currentRoot.points.Count - 1;
    }
}
