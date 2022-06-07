using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public int hp = 3;
    private int damage;
    private DeathManage dm;

    void Awake()
    {
        dm = GameObject.FindObjectOfType<DeathManage>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(
                gameObject.GetComponent<Collider2D>(),
                collisionInfo.gameObject.GetComponent<Collider2D>()
            );
        }

        if (collisionInfo.gameObject.tag == "Bullet")
        {
            damage++;

            if (damage == hp)
            {
                Destroy(gameObject);
                dm.IncreaseDeaths();
            }
        }
    }
}
