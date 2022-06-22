using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject player;
    Player p;
    public DefineStatut ds;

    public float countS;
    public float coefSpeed;
    public float countSW;
    public float countD;
    public float hp;

    void Start()
    {
        p = player.GetComponent<Player>();
        ds = GameObject.FindObjectOfType<DefineStatut>();
        countS = ds.countS;
        coefSpeed = ds.coefSpeed;
        countSW = ds.countSW;
        countD = ds.countD;
        hp = ds.hp;
    }

    public void UpBonusSpeed()
    {
        p.PlayerSpeed += p.PlayerSpeed * (countS * coefSpeed);
    }
}
