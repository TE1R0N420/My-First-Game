using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealthHandler : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;

    [SerializeField] float invincibilityTime = 1f;
    private bool isInvincible;

    [SerializeField] SpriteRenderer playerSprite;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        UIManager.instance.healthSlider.maxValue = maxHealth;
        UpdatePlayerHealth();

        isInvincible = false;
    }

   
    public void DamagePlayer(int amountOfDamage)
    {
        if (!isInvincible)
        {
            currentHealth -= amountOfDamage;
            UpdatePlayerHealth();

            MakePlayerInvincible();

            if(currentHealth <= 0)
            {
                UIManager.instance.TurnDeathScreenOn();
                AudioManager.instance.PlayGameOverMusic();
                gameObject.SetActive(false);
            }

            
        }
        

    }

    public void AddHpToPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdatePlayerHealth() ;
    }


    public void IncreaseMaxHealth(int maxHealthAmount)
    {
        maxHealth += maxHealthAmount;
        currentHealth = maxHealth;

        UIManager.instance.healthSlider.maxValue = maxHealth;
        UpdatePlayerHealth();
    }


    public void MakePlayerInvincible()
    {
        isInvincible = true;

        StartCoroutine(Flasher());
        StartCoroutine(PlayerNotInvincible());
    }

    public IEnumerator Flasher()
           {
            for(int i = 0; i < 5; i++)
            {
                playerSprite.color = new Color(
                        playerSprite.color.r,
                        playerSprite.color.g,
                        playerSprite.color.b,
                        0.1f
                    );

                yield return new WaitForSeconds(.1f);

                playerSprite.color = new Color(
                        playerSprite.color.r,
                        playerSprite.color.g,
                        playerSprite.color.b,
                        1f
                    );

                yield return new WaitForSeconds(.1f);
            }
           }


    IEnumerator PlayerNotInvincible()
    {
        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
    }



    private void UpdatePlayerHealth()
    {
        UIManager.instance.healthText.text = currentHealth + "/" + maxHealth;
        UIManager.instance.healthSlider.value = currentHealth;
    }

    public int GetPlayerMaxHealth() { return maxHealth; }

    public int GetPlayerCurrentHealth() { return currentHealth; }
}
