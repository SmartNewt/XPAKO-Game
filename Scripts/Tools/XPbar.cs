using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public DeathManage dm;

    public int xp;
    public int killed;
    public int i;
    public int level = 1;

    public Text counterText;

    void Awake()
    {
        dm = GameObject.FindObjectOfType<DeathManage>();
        SetMaxXP();
    }

    public void Update()
    {
        killed = dm.deaths;
        GainXP();
        SetXP();
        counterText.text = level.ToString();
    }

    public void SetMaxXP()
    {
        slider.maxValue = 100;
        slider.value = xp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetXP()
    {
        slider.value = xp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void GainXP()
    {
        if (i == killed)
        {
            xp += 5;
            i++;
            if (xp == 100)
            {
                xp = 0;
                level++;
            }
        }
        if (i < killed)
        {
            i = killed + 1;
        }
    }
}
