using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int enemiesNumber = 3;
    [SerializeField] private GameObject enemyPrefab;
    private float spawnRange = 8.5f;
    void Start()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            int randomEnemy = Random.Range(0, enemiesNumber);
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        } 
    }

    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.4f, spawnPosZ);
        return randomPos;
    }
}
