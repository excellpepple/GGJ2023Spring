using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    public bool isLevelActive;
    
    public bool isGameOver;
    public bool isPlayerAlive;
    
    public GameObject playerCharacter;

    public GameObject rootManager;
    
    public List<GameObject> mobsEnemies = new List<GameObject>();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        isGameOver = false;
        isLevelActive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
