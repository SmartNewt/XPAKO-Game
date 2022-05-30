using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharLifeSys : MonoBehaviour
{
    public int hp = 5;
    public int SafeTime = 2000;
    public string[] enemies;

    private int damage;
    private int tmpSafe;
    private int tmpGainLife;

    void Update()
    {
        if (damage >= hp)
        {
            Destroy(gameObject);
        }

        if (damage > 0)
        {
            if (tmpSafe == SafeTime)
            {
                if (tmpGainLife == 150)
                {
                    damage--;
                    tmpGainLife = 0;
                    if (damage == 0)
                    {
                        tmpSafe = 0;
                    }
                } else {
                    tmpGainLife++;
                }
            } else {
                tmpSafe++;
            }
        }
    }

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        int rangeTabEn = enemies.Length;

        for (int i = 0; i < rangeTabEn; i++)
        {
            if (collisionInfo.collider.name == enemies[i])
            {
                Debug.Log(damage);
                damage++;
            }
        }
    }
}
