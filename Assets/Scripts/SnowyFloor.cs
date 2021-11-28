using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowyFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entras en nieve");
            PlayerController.sharedInstance.inSnowyFloor = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Sales en nieve");
            PlayerController.sharedInstance.inSnowyFloor = false;
        }
    }
}
