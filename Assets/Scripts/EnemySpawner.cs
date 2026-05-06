using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float radius;
    [SerializeField] private float angleVariation;
    private Transform player;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay; 

    private GameMaster gm;

    private int enemyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>().GetComponent<Transform>();
        gm = FindAnyObjectByType<GameMaster>().GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWave(int count)
    {
        enemyCount = count;

        // Spawn Enemies
        for (int i = 0; i < enemyCount; i++)
        {
            StartCoroutine(spawnTimer(i));
        }

        gm.activeWaveSetup = false;
    }

    IEnumerator spawnTimer(int index)
    {
        float spawnDelay = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(spawnDelay);
        enemies.Add(SpawnEnemy(index));
    }

    GameObject SpawnEnemy(int index)
    {
        Vector2 spawnPos = getSpawnPos(index);

        // calculate rotation
        Vector2 dirToPlayer = ((Vector2)player.position - spawnPos).normalized;

        float baseAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg; // degrees
        float variation = UnityEngine.Random.Range(-1 * angleVariation, angleVariation);
        Quaternion rot = Quaternion.Euler(0f, 0f, baseAngle + variation -90f);

        return Instantiate(EnemyPrefab, spawnPos, rot);
    }

    public void StopWave()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        enemies.Clear();
    }

    private Vector2 getSpawnPos(int index)
    {
        float step = Mathf.PI * 2f / enemyCount;

        float angle = index * step;

        // small randomness inside slot
        angle += UnityEngine.Random.Range(-step * 0.3f, step * 0.3f); // radians

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector2 spawnPos = new Vector2(x, y);
        return spawnPos;
    }
}
