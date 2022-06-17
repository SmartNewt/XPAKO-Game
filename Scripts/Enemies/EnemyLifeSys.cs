using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSys : MonoBehaviour
{
    public int hp;
    public int damage;
    public GameObject xpPrefabs;
    private DeathManage dm;
    public DefineStatut ds;

    void Awake()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
        dm = GameObject.FindObjectOfType<DeathManage>();
        damage = ds.countD;
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
            Debug.Log(damage);
            hp -= damage;
            if (hp == 0 || hp < 0)
            {
                DropXP();
                Destroy(gameObject);
                dm.IncreaseDeaths();
            }
        }
    }

    private void DropXP()
    {
        GameObject XP = Instantiate(xpPrefabs, gameObject.transform.position, transform.rotation);
    }
}
