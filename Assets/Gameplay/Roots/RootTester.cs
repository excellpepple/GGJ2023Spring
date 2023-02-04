using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(RootManager))]
public class RootTester : MonoBehaviour
{
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
            if(Input.GetMouseButton(0))
            {
                Vector2 dv = new Vector2();
                dv.x = Input.GetAxis("Mouse X");
                dv.y = Input.GetAxis("Mouse Y");
                dv = dv.normalized;
                //Debug.Log(dv.ToString());
                rm.Grow(dv);
                
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rm.Grow(Vector2.up);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rm.Grow(Vector2.down);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rm.Grow(Vector2.left);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rm.Grow(Vector2.right);
            }
        }
        else
        {
            Debug.LogError("root tester can't work without assigning root manager.");
        }
        
    }
}
