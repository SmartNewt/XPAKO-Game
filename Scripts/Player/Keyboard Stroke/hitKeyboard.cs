using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitKeyboard : MonoBehaviour
{
    private int tmpLifeTime = 50;
    private int tmp;

    void Update ()
    {
        if (tmp == tmpLifeTime)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
