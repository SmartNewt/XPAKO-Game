using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] ballsPrefabs;
    public int counter = 0;

    List<GameObject> counterBalls = new List<GameObject>();

    void Update()
    {
        int counterBs = counterBalls.Count;

        if (counterBs < counter && counter <= 4)
        {
            GameObject balls = Instantiate(ballsPrefabs[0], spawnPoints[counterBalls.Count].transform.position, spawnPoints[counterBalls.Count].transform.rotation, gameObject.transform);
            counterBalls.Add(balls);
        }
    }
}
