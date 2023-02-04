using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTowardsPlayerBehaviour : MonoBehaviour
{
    public GameObject player;
    private Vector2 growthDirection;
    public RootManager rm;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rm)
        {
            GetGrowthDirection();
            rm.Grow(growthDirection);
        }
    }

    void GetGrowthDirection()
    {
        var position = player.transform.position;
        Vector2 playerPosition = new Vector2(position.x, position.y);
        growthDirection = playerPosition - rm.currentPoint.position;
    }
}
