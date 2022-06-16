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
    public Player player;
    public Select pause;

    public int xp;
    public int killed;
    private int i;
    private int a = 5;
    public int level = 1;

    public Text counterText;

    void Awake()
    {
        dm = GameObject.FindObjectOfType<DeathManage>();
        player = GameObject.FindObjectOfType<Player>();
        SetMaxXP();
    }

    void Update()
    {
        killed = dm.deaths;
        GainXP();
        SetXP();
        NewStep();
        counterText.text = level.ToString();
    }

    public void SetMaxXP()
    {
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
            i++;
            if (xp == 100 || xp > 100)
            {
                xp = 0;
                level++;
                player.currentHealth += 25;
            }
        }
        if (i < killed)
        {
            i = killed + 1;
        }
    }

    public void NewStep()
    {
        if (level == a)
        {
            Debug.Log("incroyable");
            a--;
            pause.Pause();
        }
    }
}
