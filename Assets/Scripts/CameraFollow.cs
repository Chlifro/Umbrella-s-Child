using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float separation = 6.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState != GameState.gameOver)
        {
            this.transform.position = new Vector3(player.transform.position.x + separation, this.transform.position.y,
                this.transform.position.z);    
        }
        
    }
}
