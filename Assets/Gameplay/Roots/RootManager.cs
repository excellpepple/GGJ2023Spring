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
		    Vector2 n = direction.normalized;
		    currentPoint = currentRoot.Grow(n * growDistance);
		    visualizer.setRootPoint(currentPoint);
		    lastGrowEvent = Time.time;

	    }
	    return currentPoint.position;
    }

    public void Branch(rootPoint p)
    {
	    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
