using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Vector3 positionInitial;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        positionInitial = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition(Vector3 initial)
    {
        this.transform.position = initial;
    }
}
