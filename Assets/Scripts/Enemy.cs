using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private GameObject laser;
    [SerializeField] private float initWaitTime;
    [SerializeField] private float speed;
    private bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // randomly assign speed, initWaitTime

        // Create Laser
        laser = Instantiate(laserPrefab, transform);
        laser.transform.localPosition = new Vector2(0, 10.75f);

        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(initWaitTime);
        Destroy(laser);
        isActive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World); // right = forward
    }


}
