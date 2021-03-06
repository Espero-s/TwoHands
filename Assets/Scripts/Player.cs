using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    //Camera
    private Camera cam;
    private Rigidbody2D camRb;

    //Moving
    private Rigidbody2D rb;
    public float moveSpeed;

    //UI

    //Input
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    //Shoting
    public GameObject bullet;
    public Transform rHand;
    public Transform lHand;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        cam = FindObjectOfType<Camera>();
        camRb = cam.GetComponent<Rigidbody2D>();
    }

    void pickup(int id, float worth)
    {

    }    
    void shoot(Transform hand)
    {
        Instantiate(bullet,hand.position,hand.rotation);
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);


        if(Input.GetMouseButtonDown(0))
        {
            shoot(lHand);
        }
        if (Input.GetMouseButtonDown(1))
        {
            shoot(rHand);
        }
    }
    void Controller()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        camRb.velocity += new Vector2(rb.position.x - camRb.position.x, rb.position.y - camRb.position.y) ;
        Vector2 lookDirection = mousePosition - rb.position;
        rb.rotation = Mathf.Atan2(lookDirection.y, lookDirection.x) *Mathf.Rad2Deg - 90f;
    }  
    void Update()
    {
        ProcessInputs();
    }
    private void FixedUpdate()
    {
        Controller();
    }
}
