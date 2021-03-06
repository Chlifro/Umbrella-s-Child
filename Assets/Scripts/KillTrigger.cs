using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public GameObject player;
    public AudioClip hitSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(hitSound,transform.position);
            PlayerController.sharedInstance.KillPlayer();
        }

        
    }
}
