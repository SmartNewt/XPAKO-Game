using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChoice : MonoBehaviour
{
    private GameObject[] levelChoice;
    List<int> list = new List<int>(); //  Declare list
    private int nbchoice;
    public XPbar xpb;
    private int a = 2;

    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos3;

    public void Awake()
    {
        xpb = GameObject.FindObjectOfType<XPbar>();
    }

    public void Start()
    {
        levelChoice = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            levelChoice[i] = transform.GetChild(i).gameObject;
        }

        for (int n = 0; n < 10; n++) //  Populate list
        {
            list.Add(n);
        }

        nbchoice = transform.childCount;

        SetFalse();

        pos1.x = -347;
        pos1.y = 0;

        pos2.x = 0;
        pos2.y = 0;

        pos3.x = 347;
        pos3.y = 0;

        randomnb();
    }

    private void Update()
    {
        Randomnumber();
    }

    private void SetFalse()
    {
        foreach (GameObject go in levelChoice)
        {
            go.SetActive(false);
        }
    }

    public void Randomnumber()
    {
        if (xpb.level == a)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(i + "Le chiffre d'itération");
                int randomNumber = Random.Range(1, 3);
                levelChoice[randomNumber].SetActive(true);
                Debug.Log(randomNumber + "le chiffre aléatoire");
                if (i == 0)
                {
                    levelChoice[randomNumber].transform.localPosition = pos1;
                    Debug.Log("1 case");
                }
                if (i == 1)
                {
                    levelChoice[randomNumber].transform.localPosition = pos2;
                    Debug.Log("2 case");
                }
                if (i == 2)
                {
                    levelChoice[randomNumber].transform.localPosition = pos3;
                    Debug.Log("3 case");
                }
                a++;
            }
        }
    }

    public void randomnb()
    {
        for (int i = 0; i < 9; i++)
        {
            int index = Random.Range(0, list.Count - 1); //  Pick random element from the list
            int j = list[index]; //  i = the number that was randomly picked
            list.RemoveAt(index); //  Remove chosen element
            //  Loop lines 10-13 as many times as needed
            Debug.Log(j);
        }
    }
}
