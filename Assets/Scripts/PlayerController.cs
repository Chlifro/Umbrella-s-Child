using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float initialRunningSpeed = 2.0f;
    public float currentRunningSpeed = 2.0f;
    public float jumpForce = 20.0f;
    private Rigidbody2D _rigidbody2D;
    public LayerMask LayerMaskGround;
    public Animator animator;
    public float runningSpeed = 2.0f;
    public static PlayerController sharedInstance;
    private Vector3 startPosition;
    public float distanceTravelled = 0;
    public bool inSnowyFloor = false;
    
    private void Awake()
    {
        sharedInstance = this;
        startPosition = this.transform.position;
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive",true);
        initialRunningSpeed = runningSpeed;

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void StartGame()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.None;
        animator.SetBool("isAlive",true);
        this.transform.position = startPosition;
        runningSpeed = initialRunningSpeed;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            animator.SetBool("isGrounded",isOnTheFloor());
            if (Input.GetButtonDown("Fire1"))
            {
                if (isOnTheFloor())
                {
                    Jump();
                    GetComponent<AudioSource>().Play();
                }
            }  
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            if (!inSnowyFloor)
            {
                _rigidbody2D.velocity = new Vector2(runningSpeed, _rigidbody2D.velocity.y);
                GetComponent<SpriteRenderer>().color=Color.white;
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(runningSpeed/2, _rigidbody2D.velocity.y);
                GetComponent<SpriteRenderer>().color=Color.cyan;
            }
        }
        
        
    }

    public float GetDistanceTravelled()
    {
        distanceTravelled =
            Vector2.Distance(new Vector2(startPosition.x, 0), new Vector2(this.transform.position.x, 0));

        return distanceTravelled;
    }
    
    private bool isOnTheFloor()
    {
        bool isOnTheFloor = false;
        
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f,LayerMaskGround.value))
        {
            isOnTheFloor = true;
        }
        return isOnTheFloor;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
    }

    public void KillPlayer()
    {
        Invoke("SleepPlayer",1f);
        animator.SetBool("isAlive",false);
        if(PlayerPrefs.GetFloat("highscore",0)<GetDistanceTravelled())
        {
            PlayerPrefs.SetFloat("highscore",distanceTravelled);
        }

        


    }

    public void SleepPlayer()
    {
        
        GameManager.sharedInstance.GameOver();
        Debug.Log("Has sido golpeado");

        this.transform.position = startPosition;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        
        //this.GetComponent<SpriteRenderer>().enabled = false;

        //_rigidbody2D.Sleep();

        //_rigidbody2D.velocity = Vector2.zero;
        //this._rigidbody2D.angularVelocity = 0f;


    }

    public void increaseVelocityGravity()
    {
        this.runningSpeed += 0.5f;
        this._rigidbody2D.gravityScale += 0.0025f;
    }

    public void Hitted()
    { 
        
        KillPlayer();
        Debug.Log("Has sido golepado");
        if (GameManager.sharedInstance.collectedCoins == 0)
        {
            
        }
        else
        {
            GameManager.sharedInstance.collectedCoins = 0;
        }
        //animator.SetBool("isAlive",false);
        //animator.SetBool("isAlive",true);
    }
}
