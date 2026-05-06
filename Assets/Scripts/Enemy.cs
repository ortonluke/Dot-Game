using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private GameObject laser;
    [SerializeField] private float initWaitTime;
    [SerializeField] private float flyTime;
    [SerializeField] private float speed;
    private bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // randomly assign speed, initWaitTime

        // Create Laser
        laser = Instantiate(laserPrefab, transform);
        laser.transform.localPosition = new Vector2(0, 10.75f);
    }

    public void SendLaser()
    {
        Debug.Log("Firing Laser");
        Destroy(laser);
        isActive = true;
        StartCoroutine(Flying());
    }

    IEnumerator Flying()
    {
        yield return new WaitForSeconds(flyTime);

        // Stop
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World); // up = forward
    }


}
