using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public XPbar xpmanage;
    XPbar xpbar;
    
    void Start()
    {
        xpbar = xpmanage.GetComponent<XPbar>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "XP")
        {
            xpbar.xp += 2;
        }
    }
}
