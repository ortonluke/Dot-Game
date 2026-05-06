using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private GameObject laser;
    [SerializeField] private float initWaitTime;
    [SerializeField] private float speed;
    private bool isActive = false;

    private int xBound = 15;
    private int yBound = 15;

    private Animator laserAnimator;

    private EnemySpawner eSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eSpawner = FindAnyObjectByType<EnemySpawner>().GetComponent<EnemySpawner>();

        // randomly assign speed, initWaitTime

        // Create Laser
        laser = Instantiate(laserPrefab, transform);
        laser.transform.localPosition = new Vector2(0, 10.75f);
        laserAnimator = laser.GetComponent<Animator>();

        StartCoroutine(laserFlash());
    }

    IEnumerator laserFlash()
    {
        yield return new WaitForSeconds(initWaitTime);
        laserAnimator.SetBool("isFlashing", false);
    }

    public void Fire()
    {
        Destroy(laser);
        isActive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World); // up = forward

        if (Math.Abs(transform.position.x) > xBound || Math.Abs(transform.position.y) > yBound)
        {
            Die();
        }
    }

    void Die()
    {
        eSpawner.enemies.Remove(gameObject);
        Destroy(gameObject);
    }


}
