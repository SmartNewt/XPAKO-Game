using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozambiqueere : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public GameObject[] cam;
    public GameObject[] player;
    public int nbBullets;

    public WeaponStats WS;

    List<GameObject> target = new List<GameObject>();

    private int tmp;
    // private int currentLevel = 1;
    private int baseDamage;
    // private int nbBullet = 1;
    private FindClosest FC;

    private double fireSpeed;
    private double bulletForce;

    void Start()
    {
        WeaponStats WS = gameObject.GetComponent<WeaponStats>();
        fireSpeed = WS.fireRate;
        bulletForce = WS.bulletSpeed;
        baseDamage = WS.damage;

        player = GameObject.FindGameObjectsWithTag("Player");
        cam = GameObject.FindGameObjectsWithTag("MainCamera");
        FC = player[0].GetComponent<FindClosest>();
    }

    void Update()
    {
        Aiming();
        Shoot();
        LevelUp();

        if (player == null)
        {
            Destroy(gameObject);
        }
    }

    void Aiming()
    {

        for (int i = 0; i < nbBullets; i++)
        {
            Rigidbody2D rb = firePoint.GetComponent<Rigidbody2D>();
            Vector2 lookDir = FC.FindClosestEnemy().transform.position - firePoint.transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) *((Mathf.Rad2Deg - 90f) * Random.Range(1f, 2f));
            rb.rotation = angle;
        }
    }

    void Shoot()
    {
        float BFtmp = (float)bulletForce;

        if (tmp == fireSpeed)
        {
            for (int i = 0; i < nbBullets; i++)
            {
                GameObject Bullet = Instantiate(
                    bulletPrefab,
                    firePoint.transform.position,
                    firePoint.transform.rotation
                );
                Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.transform.up * BFtmp, ForceMode2D.Impulse);
            }
            tmp = 0;
        }
        else
        {
            tmp++;
        }
    }
    void LevelUp ()
    {
        // if (currentLevel != WS.level)
        // {
        //     currentLevel = WS.level;
        //     WS.damage = baseDamage + currentLevel;

        //     if ((currentLevel % 4) == 0)
        //     {
        //         if ((currentLevel / 4) <= 3)
        //         {
        //             nbBullet = 1 + (currentLevel/4);
        //         }
        //     }
        // }
    }
}
