using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explode;

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if(bird != null)
        {
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
