using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script allows the user to switch between player character and roots
public class GlobalInputManager : MonoBehaviour
{
    public KeyCode KeySwitchCharacterRoots = KeyCode.Tab;
    /// <summary>
    /// modes:
    /// true:   controlling roots
    /// false:  controlling character
    /// </summary>
    public bool mode;

    public RootManager rm;

    public GameObject character;
    //public GameObject
    // Start is called before the first frame update
    void Start()
    {
        rm = FindObjectOfType<RootManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode) //roots
        {
            if (Input.GetKeyDown(KeySwitchCharacterRoots))
            {
                mode = !mode;
                character.SetActive(true);
                character.transform.position = rm.currentPoint.position;
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rm.Traverse(-1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rm.Traverse(1);
            }
        }
        else //character
        {
            if (Input.GetKeyDown(KeySwitchCharacterRoots))
            {
                character.SetActive(false);
                mode = !mode;
            }
        }
        

    }
}
