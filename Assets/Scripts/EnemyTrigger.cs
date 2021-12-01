using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!PlayerController.sharedInstance.hasInvencivility)
        {
            if (other.CompareTag("Player"))
            {
                if (GameManager.sharedInstance.collectedCoins == 0)
                { 
                    PlayerController.sharedInstance.KillPlayer();
                }
                else
                {
                    PlayerController.sharedInstance.animator.SetBool("isAlive",false);
                    GameManager.sharedInstance.collectedCoins = 0;
                    UpdateGameCanvas.sharedInstance.SetCoinsNumber();
                    Invoke("Hitted",1.0f);
                    //PlayerController.sharedInstance.animator.SetBool("isAlive",true);
                }
            
            }
        }
    }
    
    public void Hitted()
    {
        PlayerController.sharedInstance.ChangeState();
    }
    
}
