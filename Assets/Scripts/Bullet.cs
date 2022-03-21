using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float damage;
    public float duration;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Transform InitPosition = GetComponent<Transform>();
        rb.AddForce(InitPosition.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, duration);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {

    }
}
