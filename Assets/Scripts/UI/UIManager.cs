using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
   
    public static UIManager instance;
    
    [SerializeField] Image imageToFade;

    [SerializeField] Image weaponImage;
    [SerializeField] Text weaponName;

    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    [SerializeField] GameObject deathScreen;

    [SerializeField] TextMeshProUGUI btcText;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject bossMenu;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        if(FindAnyObjectByType<BossController>() != null)
        {
            bossMenu.SetActive(true);
        }

        StartCoroutine(UpdatePlayerUI());
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }

    public void ChangeWeaponUI(Sprite gunImage, string gunText)
    {
        weaponImage.sprite = gunImage;
        weaponName.text = gunText;
    }

    public void TurnDeathScreenOn()
    {
        deathScreen.SetActive(true);
    }

    public void UpdateBitcoinText(int amountOfBTC)
    {
        btcText.text = amountOfBTC.ToString();
    }


    public void RestartLevel()
    {
        LevelManager.instance.RestartLevel();
    }

    public void ReturnToMainMenu()
    {
        LevelManager.instance.ReturnToMainMenu();
    }


    public void TurnPauseMenuOnOff(bool onOff)
    {
        pauseMenu.SetActive(onOff);
    }

    public IEnumerator UpdatePlayerUI()
    {
        yield return new WaitForSeconds(0.1f);
        
        PlayerHealthHandler playerHealth = null;

        while(playerHealth == null)
        {
            playerHealth = FindFirstObjectByType<PlayerHealthHandler>();
        }

        healthSlider.maxValue = playerHealth.GetPlayerMaxHealth();
        healthSlider.value = playerHealth.GetPlayerCurrentHealth();

        healthText.text = playerHealth.GetPlayerCurrentHealth() + "/" + playerHealth.GetPlayerMaxHealth();
        btcText.text = GameManager.instance.GetCurrentBitcoins().ToString();
    
    }
   
}
