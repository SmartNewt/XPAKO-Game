using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerXP : MonoBehaviour
{
    public XPbar xpmanage;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "XP")
        {
            xpmanage.xp += 2;
            Debug.Log(xpmanage.xp);
        }
    }
}
