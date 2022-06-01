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
        dm = GameObject.FindObjectOfType<DeathManage>();
        Debug.Log(dm.deaths);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        LoadPlayer();
    }

    private void Start() { }

    public void Update()
    {
        killed = dm.deaths;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TakeDamage(1);
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
