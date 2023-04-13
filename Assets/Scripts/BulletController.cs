using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    private void Start()
    {
        // Set a timer to deactivate the bullet after its lifetime expires
        Invoke("DeactivateBullet", bulletLifetime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // If a bullet hits an enemy, deactivate the bullet and the enemy
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        // If a bullet goes off-screen, deactivate it
        gameObject.SetActive(false);
    }

    void DeactivateBullet()
    {
        // Deactivate the bullet after its lifetime expires
        gameObject.SetActive(false);
    }
}

