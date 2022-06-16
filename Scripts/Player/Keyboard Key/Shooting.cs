using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject[] firePoint;
    public GameObject[] bulletPrefab;
    public WeaponStats WS;

    private int tmp;
    private int currentLevel = 1;
    private int baseDamage;
    private int nbBullet = 1;
    private GameObject[] player;
    private FindClosest FC;
    private GameObject[] Cam;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        Cam = GameObject.FindGameObjectsWithTag("MainCamera");
        FC = player[0].GetComponent<FindClosest>();
        baseDamage = WS.damage;
    }

    void Update()
    {
        Aiming();
        Shoot();
        LevelUp();
    }

    void Aiming()
    {
        int nbFirePoints = firePoint.Length;

        for (int i = 0; i < nbFirePoints; i++)
        {
            Rigidbody2D rb = firePoint[i].GetComponent<Rigidbody2D>();
            Vector2 lookDir = FC.FindClosestEnemy().transform.position - firePoint[i].transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    void Shoot()
    {
        if(tmp == WS.fireRate)
        {
            int randPoints;
            GameObject bullet;
            GameObject bullet1;
            GameObject bullet2;
            Rigidbody2D rb;
            Rigidbody2D rb1;
            Rigidbody2D rb2;

            switch (nbBullet)
            {
                case 2 :
                    randPoints = Random.Range(0, firePoint.Length);
                    bullet = Instantiate(bulletPrefab[2], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                    bullet.transform.SetParent(gameObject.transform);
                    rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                    randPoints = Random.Range(0, firePoint.Length);
                    bullet1 = Instantiate(bulletPrefab[5], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                    bullet1.transform.SetParent(gameObject.transform);
                    rb1 = bullet1.GetComponent<Rigidbody2D>();
                    rb1.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                    break;

                case 3 :
                    int randComb = Random.Range(0, 5);
                    switch (randComb)
                    {
                        case 0 :
                            randPoints = Random.Range(0, firePoint.Length);
                            bullet = Instantiate(bulletPrefab[1], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet.transform.SetParent(gameObject.transform);
                            rb = bullet.GetComponent<Rigidbody2D>();
                            rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet1 = Instantiate(bulletPrefab[5], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet1.transform.SetParent(gameObject.transform);
                            rb1 = bullet1.GetComponent<Rigidbody2D>();
                            rb1.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet2 = Instantiate(bulletPrefab[2], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet2.transform.SetParent(gameObject.transform);
                            rb2 = bullet2.GetComponent<Rigidbody2D>();
                            rb2.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            break;
                        case 1 :
                            randPoints = Random.Range(0, firePoint.Length);
                            bullet = Instantiate(bulletPrefab[6], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet.transform.SetParent(gameObject.transform);
                            rb = bullet.GetComponent<Rigidbody2D>();
                            rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet1 = Instantiate(bulletPrefab[7], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet1.transform.SetParent(gameObject.transform);
                            rb1 = bullet1.GetComponent<Rigidbody2D>();
                            rb1.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet2 = Instantiate(bulletPrefab[0], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet2.transform.SetParent(gameObject.transform);
                            rb2 = bullet2.GetComponent<Rigidbody2D>();
                            rb2.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            break;
                        case 2 :
                            randPoints = Random.Range(0, firePoint.Length);
                            bullet = Instantiate(bulletPrefab[7], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet.transform.SetParent(gameObject.transform);
                            rb = bullet.GetComponent<Rigidbody2D>();
                            rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet1 = Instantiate(bulletPrefab[6], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet1.transform.SetParent(gameObject.transform);
                            rb1 = bullet1.GetComponent<Rigidbody2D>();
                            rb1.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet2 = Instantiate(bulletPrefab[2], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet2.transform.SetParent(gameObject.transform);
                            rb2 = bullet2.GetComponent<Rigidbody2D>();
                            rb2.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            break;
                        case 3 :
                            randPoints = Random.Range(0, firePoint.Length);
                            bullet = Instantiate(bulletPrefab[1], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet.transform.SetParent(gameObject.transform);
                            rb = bullet.GetComponent<Rigidbody2D>();
                            rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet1 = Instantiate(bulletPrefab[3], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet1.transform.SetParent(gameObject.transform);
                            rb1 = bullet1.GetComponent<Rigidbody2D>();
                            rb1.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet2 = Instantiate(bulletPrefab[6], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet2.transform.SetParent(gameObject.transform);
                            rb2 = bullet2.GetComponent<Rigidbody2D>();
                            rb2.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            break;
                        case 4 :
                            randPoints = Random.Range(0, firePoint.Length);
                            bullet = Instantiate(bulletPrefab[0], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet.transform.SetParent(gameObject.transform);
                            rb = bullet.GetComponent<Rigidbody2D>();
                            rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet1 = Instantiate(bulletPrefab[1], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet1.transform.SetParent(gameObject.transform);
                            rb1 = bullet1.GetComponent<Rigidbody2D>();
                            rb1.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            randPoints = Random.Range(0, firePoint.Length);
                            bullet2 = Instantiate(bulletPrefab[2], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                            bullet2.transform.SetParent(gameObject.transform);
                            rb2 = bullet2.GetComponent<Rigidbody2D>();
                            rb2.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);

                            break;
                        default :
                            for (int i = 0; i < nbBullet; i++)
                            {
                                randPoints = Random.Range(0, firePoint.Length);
                                int randBullet = Random.Range(0, bulletPrefab.Length);
                                bullet = Instantiate(bulletPrefab[randBullet], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                                bullet.transform.SetParent(gameObject.transform);
                                rb = bullet.GetComponent<Rigidbody2D>();
                                rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);
                            }
                            break;
                    }
                    break;
                default:
                    for (int i = 0; i < nbBullet; i++)
                    {
                        randPoints = Random.Range(0, firePoint.Length);
                        int randBullet = Random.Range(0, bulletPrefab.Length);
                        bullet = Instantiate(bulletPrefab[randBullet], firePoint[randPoints].transform.position, firePoint[randPoints].transform.rotation);
                        bullet.transform.SetParent(gameObject.transform);
                        rb = bullet.GetComponent<Rigidbody2D>();
                        rb.AddForce(firePoint[randPoints].transform.up * (float)WS.bulletSpeed, ForceMode2D.Impulse);
                    }
                    break;
            }

            tmp = 0;
        } else {
            tmp++;
        }
    }

    void LevelUp ()
    {
        if (currentLevel != WS.level)
        {
            currentLevel = WS.level;
            WS.damage = baseDamage + currentLevel;

            if ((currentLevel % 4) == 0)
            {
                if ((currentLevel / 4) <= 3)
                {
                    nbBullet = 1 + (currentLevel/4);
                }
            }
        }
    }
}