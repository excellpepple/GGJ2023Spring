using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script allows the user to switch between player character and roots
public class GlobalInputManager : MonoBehaviour
{
    public KeyCode KeySwitchCharacterRoots = KeyCode.Tab;
    public bool mode;

    public GameObject character;
    //public GameObject
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mode)
        {

        }
        else
        {
        }
        
        if (Input.GetKeyDown(KeySwitchCharacterRoots))
        {
            mode = !mode;
        }
    }
}
