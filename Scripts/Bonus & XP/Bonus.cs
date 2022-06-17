using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    void Start ()
    {
        Vector3 pos = transform.position;
        pos.z = 1;
        transform.position = pos;
    }

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        } else {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collisionInfo.gameObject.GetComponent<Collider2D>());
        }
    }
}
