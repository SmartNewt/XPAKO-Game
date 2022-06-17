using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public int level = 1;
    public double bulletSpeed;

    public double fireRate;
    public int damage;

    GameObject player;
    MainCharLifeSys MCL;
    
    // void Update ()
    // {
    //     GameObject player = GameObject.Find("MainChar");
    //     MainCharLifeSys MCL = player.GetComponent<MainCharLifeSys>();
    //     damage = MCL.damageWeapon;
    //     fireRate = MCL.speedWeapon;
    // }
}
