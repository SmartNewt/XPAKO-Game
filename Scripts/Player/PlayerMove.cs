using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;

    private double playerSpeed;
    Vector2 movement;

    void Start()
    {
        MainCharLifeSys MCL = gameObject.GetComponent<MainCharLifeSys>();
        playerSpeed = MCL.PlayerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        float PS = (float)playerSpeed;

        rb.MovePosition(rb.position + movement * PS * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(
                gameObject.GetComponent<Collider2D>(),
                collision.gameObject.GetComponent<Collider2D>()
            );
        }
    }
}
