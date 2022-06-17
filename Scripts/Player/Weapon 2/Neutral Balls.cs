using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralBalls : MonoBehaviour
{
    void OnTriggerEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
