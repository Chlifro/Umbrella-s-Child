using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameOverCanvas : MonoBehaviour
{
    public static UpdateGameOverCanvas sharedInstance;

    public Text coinsNumber;

    public Text scorePoints;

    private void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScorePointsAndCoins()
    {
        scorePoints.text = PlayerController.sharedInstance.GetDistanceTravelled().ToString("f0");
        coinsNumber.text = GameManager.sharedInstance.collectedCoins.ToString();
    }
}
