using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxBehaviour : MonoBehaviour
{
    public Entity Owner; // game object attacking the target
    public float damagePoints; // how much damage points a hit should have
    public string TargetTag;// what's the gameobjects tag you want to damage.
    public Entity Target;
    public bool isShootable = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            Debug.Log("We Hit something!");
            //Owner.AttackObject(collision.gameObject);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
