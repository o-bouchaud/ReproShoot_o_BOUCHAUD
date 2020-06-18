using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform enemy;
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
            Destroy(gameObject);
        }
    }
    void OnColliderEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(enemy.gameObject);
            SceneManager.LoadScene("Win");

        }
    }
}
