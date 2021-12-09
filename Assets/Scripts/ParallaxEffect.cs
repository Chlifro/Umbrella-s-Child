using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxMultipler;
    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    private float spriteWidth;

    private float starPosition;
    private float initPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        starPosition = transform.position.x;
        initPosition = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.transform.position.x - previousCameraPosition.x)*parallaxMultipler;
        float moveAmount = cameraTransform.position.x * (1 - parallaxMultipler);
        transform.Translate(new Vector3(deltaX,0,0));
        previousCameraPosition = cameraTransform.position;
    
        
        if (moveAmount > starPosition + spriteWidth)
        {
            
            transform.Translate(new Vector3( spriteWidth,0,0));
            starPosition += spriteWidth;
        }
        
    }

    public void ResetPosition()
    {
        Debug.Log("RESET");
        transform.Translate(new Vector3((cameraTransform.transform.position.x - previousCameraPosition.x)*parallaxMultipler,0,0));
    }
}
