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

        UIManager.instance.healthSlider.maxValue = maxHealth;
        UpdatePlayerHealth();
    }

   
    public void DamagePlayer(int amountOfDamage)
    {
        currentHealth -= amountOfDamage;
        UpdatePlayerHealth();


        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdatePlayerHealth()
    {
        UIManager.instance.healthText.text = currentHealth + "/" + maxHealth;
        UIManager.instance.healthSlider.value = currentHealth;
    }


}
