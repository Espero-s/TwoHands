using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hands : MonoBehaviour
{
    public Rigidbody2D rb;

    public Rigidbody2D eyeRb;
    public Rigidbody2D playerRb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerRb = collision.GetComponent<Rigidbody2D>();
            Vector2 lookDirection = playerRb.position - rb.position;
            eyeRb.rotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        }
    }
}
