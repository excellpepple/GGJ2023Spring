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
	public Root BaseRoot; //resisted the temptation to call this RootRoot
	public Root CurrentRoot; //the root the player is modifying at the moment
	
	//timing
	public float lastGrowEvent;

	void Start()
	{
		lastGrowEvent = Time.time;
	    if (RootType)
	    {
		    BaseRoot = Instantiate(RootType, transform).GetComponent<Root>();
		    CurrentRoot = BaseRoot;
	    }
	    else
	    {
		    Debug.LogError("Root prefab hasn't been assigned to RootManager ");
	    }
    }

    public void Grow(Vector2 direction)
    {
	    if (Time.time - lastGrowEvent > growCooldown)
	    {
		    Vector2 n = direction.normalized;
		    //CurrentRoot.Grow(n * growDistance);
		    CurrentRoot.Grow(n * growDistance);
		    lastGrowEvent = Time.time;
	    }
	    else
	    {
		    //Debug.Log("not ready yet");
	    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
