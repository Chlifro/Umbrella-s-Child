using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.sharedInstance.collectedCoins == 0)
            {
                if (!PlayerController.sharedInstance.hasInvencivility)
                {
                    PlayerController.sharedInstance.KillPlayer();    
                }
                    
            }
            else
            {
                GameManager.sharedInstance.collectedCoins = 0;
                UpdateGameCanvas.sharedInstance.SetCoinsNumber();
            }
            
        }
    }
}
