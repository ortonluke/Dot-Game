using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    private List<GameObject> enemies;
    [SerializeField] private float radius;
    private GameMaster gm;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject SpawnEnemy()
    {
        float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f); // radians

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        return Instantiate(EnemyPrefab, new Vector2(x, y), Quaternion.identity);
    }

    public void StartWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Debug.Log("Spawning Enemy: " + i);
            //enemies.Add(SpawnEnemy());
            SpawnEnemy();
        }
    }
}
