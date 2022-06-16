using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    public static int SelectedChar;
    PlayerStatus ps;
    GameObject go;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
    }

    private void SetFalse()
    {
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
    }

    public void Char1()
    {
        SelectedChar = 1;
        SetFalse();
        characterList[0].SetActive(true);
    }

    public void Char2()
    {
        SelectedChar = 2;
        SetFalse();
        characterList[1].SetActive(true);
    }

    public void Char3()
    {
        SelectedChar = 3;
        SetFalse();
        characterList[2].SetActive(true);
    }

    public void Char4()
    {
        SelectedChar = 4;
        SetFalse();
        characterList[3].SetActive(true);
    }

    public void Char5()
    {
        SelectedChar = 5;
        SetFalse();
        characterList[4].SetActive(true);
    }

    public void Char6()
    {
        SelectedChar = 6;
        SetFalse();
        characterList[5].SetActive(true);
    }

    public void Char7()
    {
        SelectedChar = 7;
        SetFalse();
        characterList[6].SetActive(true);
    }
}
