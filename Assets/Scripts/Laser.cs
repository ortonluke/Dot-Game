using UnityEngine;

public class Laser : MonoBehaviour
{
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }

    void Fire()
    {
        Debug.Log("Fire");
        enemy.SendLaser();
    }
}
