using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossHealthHandler : MonoBehaviour
{

    [SerializeField] int bossMaxHealth = 500;
    public int bossCurrentHealth;
    
    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossCurrentHealth = bossMaxHealth;
    }

    public void TakeDamage(int amountOfDamage)
    {
        if(isInvincible) { return; }
        
        bossCurrentHealth -= amountOfDamage;

        if(bossCurrentHealth <= bossMaxHealth / 2)
        {
            GetComponent<Animator>().SetTrigger("Get Angry");
        }

        if(bossCurrentHealth <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
        }
    }


    public void DestroyTheBoss()
    {
        Destroy(gameObject);
    }

    public int GetBossMaxHealth() { return bossMaxHealth; }

    public int GetBossCurrentHealth() { return bossCurrentHealth; }


    public void SetTheBossInvincible(bool isBossInvincible) { isInvincible = isBossInvincible; }
}
