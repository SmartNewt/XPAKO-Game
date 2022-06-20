using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozambiqueere : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public GameObject player;
    public int nbBullets;

    List<GameObject> target = new List<GameObject>();

    private double fireSpeed;
    private double bulletForce;
    private int tmp;
    private int index = 0;

    void Start()
    {
        WeaponStats WS = gameObject.GetComponent<WeaponStats>();
        fireSpeed = WS.fireRate;
        bulletForce = WS.bulletSpeed;
    }

    void Update()
    {
        SetTarget();
        if (target[index] != null)
        {
            Aiming();
            Shoot();
        }

        if (player == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player" || colliderInfo.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), colliderInfo.gameObject.GetComponent<Collider2D>());
        }
        if (colliderInfo.gameObject.tag == "Enemy")
        {
            target.Add(colliderInfo.gameObject);
            Debug.Log("ninporte quoi jsp");
        }
    }

    int SetTarget()
    {
        while (target[index] == null)
        {
            index++;
        }
        return index;
    }

    void Aiming()
    {
        for (int i = 0; i < nbBullets; i++)
        {
            Rigidbody2D rb = firePoint.GetComponent<Rigidbody2D>();
            Vector2 lookDir = target[index].transform.position - firePoint.transform.position * Random.Range(1f, 2f);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    void Shoot()
    {
        float BFtmp = (float)bulletForce;

        if (tmp == fireSpeed)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject bullet = Instantiate(
                    bulletPrefab,
                    firePoint.transform.position,
                    firePoint.transform.rotation
                );
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.transform.up * BFtmp, ForceMode2D.Impulse);
            }
            tmp = 0;
        }
        else
        {
            tmp++;
        }
    }
}
