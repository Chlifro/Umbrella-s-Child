using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public bool staticEnemy;
    public float runningSpeed = 1f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

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
                    AudioSource.PlayClipAtPoint(PlayerController.sharedInstance.playerCoins,PlayerController.sharedInstance.transform.position);
                    PlayerController.sharedInstance.animator.SetBool("isAlive",false);
                    PlayerController.sharedInstance.particulasMonedas.Play();
                    GameManager.sharedInstance.collectedCoins = 0;
                    UpdateGameCanvas.sharedInstance.SetCoinsNumber();
                    Invoke("Hitted",0.5f);
                    //PlayerController.sharedInstance.animator.SetBool("isAlive",true);
                }
            
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       
            Destroy(this.gameObject);     
        
    }

    public void Hitted()
    {
        PlayerController.sharedInstance.ChangeState();
        PlayerController.sharedInstance.particulasMonedas.Stop();
    }

    private void FixedUpdate()
    {
        if (!staticEnemy)
        {
            _rigidbody2D.velocity = new Vector2(-runningSpeed,_rigidbody2D.velocity.y);    
        }
        
    }
}
