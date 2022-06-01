using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManage : MonoBehaviour
{
    public int deaths;

    void Awake()
    {
    }

    public void IncreaseDeaths()
    {
        deaths += 1;
    }
}
