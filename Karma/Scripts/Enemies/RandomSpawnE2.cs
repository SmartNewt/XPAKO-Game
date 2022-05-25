using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnE2 : MonoBehaviour
{
    public Transform player;
    public Transform[] spawnPoints;
    public GameObject enemyPrefabs;
    public int TimeForSpawn = 3000;

    private int tmp;

    void Update()
    {
        if (tmp == TimeForSpawn)
        {
            int rangeSP = spawnPoints.Length;

            for (int i = 0; i < rangeSP ; i++)
            {
                GameObject enemy = Instantiate(enemyPrefabs, spawnPoints[i].position, transform.rotation);
            }

            tmp = 0;
        } else {
            tmp++;
        }
    }
}
