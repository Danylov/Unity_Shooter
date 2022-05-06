using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int enemiesNumber = 3;
    [SerializeField] private GameObject enemyPrefab;
    private float spawnRange = 8.5f;
    public float rotationSpeed = 30.0f;
    private List<GameObject> enemies= new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            enemy.transform.SetParent(transform);
            enemies.Add(enemy);
        } 
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.4f, spawnPosZ);
        return randomPos;
    }
}