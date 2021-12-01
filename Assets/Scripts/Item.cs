using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemsType
    {
        Coin,
        StarPower
    }

    public ItemsType itemType;
    public AudioClip itemSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (itemType == ItemsType.Coin)
            {
                GameManager.sharedInstance.CollectCoin();
                AudioSource.PlayClipAtPoint(itemSound,gameObject.transform.position);
                Destroy(gameObject);     
            }

            if (itemType == ItemsType.StarPower)
            {
                //PlayerController.sharedInstance.active;
                Destroy(gameObject);     
            }
            
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
