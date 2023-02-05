using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GlobalInputManager gim;
    
    public GameObject player;
    public Transform rootControls;
    
    public Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        gim = FindObjectOfType<GlobalInputManager>();
        rootControls = FindObjectOfType<RootInputVisualizer>().gameObject.transform;
    }
	
    // Update is called once per frame
    void LateUpdate ()
    {
        if (gim.mode)
        {
            transform.position = rootControls.position + offset;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
