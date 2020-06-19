using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Win();
        }
    
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("Touching Player");
            Die();
        }
    /*if (gameObject.tag == "Bullet")
    {
        Win();
    }

    if (gameObject.tag == "Player")
     {
        Die();
     }*/
    }
    

    /*void OnTriggerEnter2D(Collider2D other)
 {
    if (other.tag == "Bullet")
    {
        Destroy(other.gameObject);
    }

    if (other.tag == "Player")
     {
        Destroy(other.gameObject);
     }
 }*/

    private void Die()
    {
        Debug.Log("Die function");
        Destroy(gameObject);
        SceneManager.LoadScene("Lose");
    }

    private void Win()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Win");
    }
}
