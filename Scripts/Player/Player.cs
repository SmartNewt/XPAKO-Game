using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int Armor;
    public int level;
    public int BulletSpeed;
    public int CoolDown;
    public int currentHealth;
    public int killed;
    public HealthBar healthBar;
    public DeathManage dm;

    void Awake()
    {
        LoadPlayer();
        dm = GameObject.FindObjectOfType<DeathManage>();
        Debug.Log(dm.deaths);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Start() { }

    public void Update()
    {
        killed = dm.deaths;
        healthBar.SetHealth(currentHealth);
    }

    void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(this);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }

        if (currentHealth == 0 || currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > 101)
        {
            currentHealth = 100;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        currentHealth = data.health;
        killed = data.killed;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
