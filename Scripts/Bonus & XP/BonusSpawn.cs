using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] bonusPrefabs;
    public int TimeForSpawn;

    private int tmp;

    void Update()
    {
        if (tmp == TimeForSpawn)
        {
            int randBonus = Random.Range(0, bonusPrefabs.Length);
            int randPoints = Random.Range(0, spawnPoints.Length);
                
            GameObject enemy = Instantiate(bonusPrefabs[randBonus], spawnPoints[randPoints].position, transform.rotation);

            tmp = 0;
        } else {
            tmp++;
        }
    }
}
