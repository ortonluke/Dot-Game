using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int maxSpawn;
    private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float radius;
    [SerializeField] private float angleVariation;
    private GameMaster gm;
    private Transform player;
    [SerializeField] private float waveDelay;

     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameMaster>();
        player = FindAnyObjectByType<Player>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<float> usedAngles = new List<float>();
    [SerializeField] private float minAngleDistance;

    GameObject SpawnEnemy(int index, int total)
    {
        Vector2 spawnPos = getSpawnPos(index, total);

        // calculate rotation
        Vector2 dirToPlayer = ((Vector2)player.position - spawnPos).normalized;

        float baseAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg; // degrees
        float variation = UnityEngine.Random.Range(-1 * angleVariation, angleVariation);
        Quaternion rot = Quaternion.Euler(0f, 0f, baseAngle + variation -90f);

        return Instantiate(EnemyPrefab, spawnPos, rot);
    }

    public void StartWave(int enemyCount)
    {
        // Spawn Enemies
        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(SpawnEnemy(i, enemyCount));
        }
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(waveDelay);
        
    }

    public void StopWave()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    private Vector2 getSpawnPos(int index, int total)
    {
        float step = (Mathf.PI * 2f) / total;

        float angle = index * step;

        // small randomness inside slot
        angle += UnityEngine.Random.Range(-step * 0.3f, step * 0.3f); // radians

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    }
}
