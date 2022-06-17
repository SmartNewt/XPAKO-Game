using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharLifeSys : MonoBehaviour
{
    public int hp = 5;
    public int SafeTime = 2000;
    public string[] enemies;
    public double PlayerSpeed = 50;

    private int damage;
    private int tmpSafe;
    private int tmpGainLife;

    public double damageWeapon = 1.0;
    public double speedWeapon = 200.0;

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
                }
                else
                {
                    tmpGainLife++;
                }
            }
            else
            {
                tmpSafe++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Bonus")
        {
            if (collisionInfo.gameObject.name == "Speed+(Clone)")
            {
                PlayerSpeed = PlayerSpeed * 1.1;
            }

            if (collisionInfo.gameObject.name == "Damage+(Clone)")
            {
                damageWeapon = damageWeapon * 1.1;
            }

            if (collisionInfo.gameObject.name == "SpeedWeapon+(Clone)")
            {
                speedWeapon = speedWeapon * 0.9;
            }
        }

        int rangeTabEn = enemies.Length;

        for (int i = 0; i < rangeTabEn; i++)
        {
            if (collisionInfo.collider.name == enemies[i])
            {
                damage++;
            }
        }

        if (collisionInfo.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(
                gameObject.GetComponent<Collider2D>(),
                collisionInfo.gameObject.GetComponent<Collider2D>()
            );
        }
    }
}
