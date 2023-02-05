using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTowardsPlayerBehaviour : MonoBehaviour
{
    //public GameObject player;
    private Vector2 growthDirection;
    public RootManager rm;
    public Vector3 lastGrowPos;
    
    // Start is called before the first frame update
    void Start()
    {
        lastGrowPos = transform.position;
        rm = FindObjectOfType<RootManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rm)
        {
            //only grow roots if we moved far away enough from the last root point.
            if (Vector2.Distance(new Vector2(lastGrowPos.x, lastGrowPos.y),new Vector2(transform.position.x, transform.position.y)) > rm.growDistance)
            {
                //Debug.Log("growing:\n lastGrowPos:" + lastGrowPos.ToString() + "\n position: " + transform.position.ToString() + "\n growdistance: " + rm.growDistance.ToString());
                GetGrowthDirection();
                lastGrowPos = rm.Grow(growthDirection);
            }
        }
    }

    void GetGrowthDirection()
    {
        var position = transform.position;
        Vector2 playerPosition = new Vector2(position.x, position.y);
        growthDirection = playerPosition - rm.currentPoint.position;
    }
}
