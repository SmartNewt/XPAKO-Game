using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyborardStroke : MonoBehaviour
{
    public GameObject prefab;
    public GameObject hitPoint;
    public WeaponStats WS;

    private FindClosest FC;
    private int currentLevel;
    private int tmp;

    void Start ()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        FC = player[0].GetComponent<FindClosest>();
        currentLevel = WS.level;
    }

    void Update ()
    {
        Aiming();
        Hit();
        LevelUp();
    }

    void Aiming ()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = FC.FindClosestEnemy().transform.position - this.gameObject.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Hit ()
    {
        if (tmp == WS.fireRate)
        {
            GameObject keyBoard = Instantiate(prefab, hitPoint.transform.position, hitPoint.transform.rotation);
            keyBoard.transform.SetParent(gameObject.transform);

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
            WS.damage = WS.damage + (2*currentLevel);
        }
    }
}
