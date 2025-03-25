using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealthHandler : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

   
    public void DamagePlayer(int amountOfDamage)
    {
        currentHealth -= amountOfDamage;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
