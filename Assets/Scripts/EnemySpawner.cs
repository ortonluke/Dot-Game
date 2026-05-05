using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    private List<GameObject> enemies = new List<GameObject>();
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

    private List<float> usedAngles = new List<float>();
    [SerializeField] private float minAngleDistance;

    GameObject SpawnEnemy(int index, int total)
    {
        float step = (Mathf.PI * 2f) / total;

        float angle = index * step;

        // small randomness inside slot
        angle += UnityEngine.Random.Range(-step * 0.3f, step * 0.3f);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        return Instantiate(EnemyPrefab, new Vector2(x, y), Quaternion.identity);
    }

    public void StartWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(SpawnEnemy(i, enemyCount));
        }
    }

    public void StopWave()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
