using System;
using UnityEditor;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float spawnRate; // per second
    private int currentCount;
    [SerializeField] private float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float degree = UnityEngine.Random.Range(0.0f, 360.0f);
        double x = Math.Cos(degree) * radius;
        double y = Math.Sin(degree) * radius;
    }
}
