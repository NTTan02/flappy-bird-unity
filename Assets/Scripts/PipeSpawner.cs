using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe Prefabs")]
    public GameObject pipePairPrefab_Type1;
    public GameObject pipePairPrefab_Type2;
    public GameObject pipePairPrefab_Type3;

    [Header("Spawn Settings")]
    public float spawnRate = 1.5f;
    public float heightOffset = 1.5f;

    [Header("Spawn Chances (%)")]
    [Range(0, 100)]
    public float type1Chance = 50f;
    [Range(0, 100)]
    public float type2Chance = 30f;
    [Range(0, 100)]
    public float type3Chance = 20f;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 1.5f, spawnRate);
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomY);

        int pipeType;
        GameObject selectedPipe = SelectPipeType(out pipeType);
        
        if (selectedPipe != null)
        {
            GameObject spawnedPipe = Instantiate(selectedPipe, spawnPosition, Quaternion.identity);
            
            ScoreZone scoreZone = spawnedPipe.GetComponentInChildren<ScoreZone>();
            if (scoreZone != null)
            {
                scoreZone.pipeType = pipeType;
            }
        }
    }

    GameObject SelectPipeType(out int pipeType)
    {
        float randomValue = Random.Range(0f, 100f);
        
        if (randomValue < type1Chance)
        {
            pipeType = 1;
            return pipePairPrefab_Type1;
        }
        else if (randomValue < type1Chance + type2Chance)
        {
            pipeType = 2;
            return pipePairPrefab_Type2;
        }
        else
        {
            pipeType = 3;
            return pipePairPrefab_Type3;
        }
    }
}