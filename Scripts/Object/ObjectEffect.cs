using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffect : MonoBehaviour
{
    public DefineStatut ds;
    public float epine;
    private int a = 0;

    public void Start()
    {
        ds = GameObject.FindObjectOfType<DefineStatut>();
    }

    public void LvlDown()
    {
        ds.countD++;
    }

    public void Sebum()
    {
        ds.armor = (float)(ds.armor * 1.05);
    }

    public void loiz()
    {
        ds.hp += 20;
    }

    public void Epine()
    {
        epine = ds.armor;
    }

    public void SaintTriangle()
    {
        a++;
        if (a == 2)
        {
            ds.armor++;
            ds.countD++;
            ds.countS++;
        }
    }
}
