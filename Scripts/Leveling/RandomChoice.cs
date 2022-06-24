using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChoice : MonoBehaviour
{
    private GameObject[] levelChoice;
    List<int> list = new List<int>(); //  Declare list
    private int nbchoice;
    public XPbar xpb;
    public Select slct;
    private int a = 2;

    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos3;

    public void Awake()
    {
        xpb = GameObject.FindObjectOfType<XPbar>();
        slct = GameObject.FindObjectOfType<Select>();
    }

    public void Start()
    {
        levelChoice = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            levelChoice[i] = transform.GetChild(i).gameObject;
        }

        nbchoice = transform.childCount;

        for (int n = 0; n < nbchoice; n++) //  Populate list
        {
            list.Add(n);
        }

        SetFalse();

        pos1.x = -347;
        pos1.y = 0;

        pos2.x = 0;
        pos2.y = 0;

        pos3.x = 347;
        pos3.y = 0;
    }

    private void Update()
    {
        Randomnumber();
    }

    public void SetFalse()
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
            SetFalse();
            for (int i = 0; i < 3; i++)
            {
                int index = Random.Range(0, list.Count); //  Pick random element from the list
                int j = list[index]; //  i = the number that was randomly picked
                list.RemoveAt(index); //  Remove chosen element
                levelChoice[j].SetActive(true);
                if (i == 0)
                {
                    levelChoice[j].transform.localPosition = pos1;
                }
                if (i == 1)
                {
                    levelChoice[j].transform.localPosition = pos2;
                }
                if (i == 2)
                {
                    levelChoice[j].transform.localPosition = pos3;
                }
                a++;
            }
        }
    }
}
