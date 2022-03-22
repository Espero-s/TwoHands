using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D player;
    private float chasetime;
    public float speed;
    public float health;
    public GameObject deathParticles;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
   {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2((player.position.x - rb.position.x) * speed, (player.position.y - rb.position.y) * speed);
            chasetime = 5f;
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(deathParticles, rb.transform.position, rb.transform.rotation);
    }

    void Update()
    {
        chasetime -= 1f;
        if (chasetime <= 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
