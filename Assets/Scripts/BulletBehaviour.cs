using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform enemy;
    private Vector2 target;


    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        target = new Vector2 (enemy.position.x, enemy.position.y);

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
