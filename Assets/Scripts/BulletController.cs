using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    private void Start()
    {
       
        Invoke("DeactivateBullet", bulletLifetime);
    }

    void Update()
    {
        
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        
        gameObject.SetActive(false);
    }

    void DeactivateBullet()
    {
        
        gameObject.SetActive(false);
    }
}

