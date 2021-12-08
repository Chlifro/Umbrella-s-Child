using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UI;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedInstance;

    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();

    public Transform levelInitialPoint;

    public bool isGeneratingInitialBlocks;

    private void Awake()
    {
        sharedInstance = this;
    }

    public void RemoveOldBlock()
    {
        LevelBlock block = currentLevelBlocks[0];
        currentLevelBlocks.Remove(block);
        Destroy(block.gameObject);
    }

    public void RemoveAllBlocks()
    {
        while (currentLevelBlocks.Count > 0)
        {
            RemoveOldBlock();    
        }
    }
    public void GenerateInitialBlocks()
    {
        if (currentLevelBlocks.Count == 0)
        {
            isGeneratingInitialBlocks = true;
            for (int i = 0; i < 3; i++)
            {
                AddNewBlock();
            }
        }
        isGeneratingInitialBlocks = false;
    }
    
    public void AddNewBlock()
    {
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

        if (isGeneratingInitialBlocks)
        {
            randomIndex = 0;
        }

        LevelBlock block = Instantiate(allTheLevelBlocks[randomIndex]);
        
            block.transform.SetParent(this.transform,false);

        Vector3 blockPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            blockPosition = levelInitialPoint.position;
        }
        else
        {
            blockPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }
        
        block.transform.position = blockPosition;
        
        currentLevelBlocks.Add(block);
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
