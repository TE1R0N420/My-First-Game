using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class WeaponsChest : MonoBehaviour
{

    [SerializeField] WeaponsPickup[] potentialWeapons;
    private SpriteRenderer chestSR;

    [SerializeField] Sprite openChestSprite;
    [SerializeField] TextMeshProUGUI openKeyText;

    [SerializeField] Transform spawnPoint;

    private bool canOpen, hasBeenOpened;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chestSR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen && !hasBeenOpened)
        {
            chestSR.sprite = openChestSprite;


            int randomWeaponNumber = Random.Range(0, potentialWeapons.Length);
            Instantiate(potentialWeapons[randomWeaponNumber], spawnPoint.position, spawnPoint.rotation);

            hasBeenOpened = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(!hasBeenOpened)
       {
          openKeyText.gameObject.SetActive(true);
       }
        
        canOpen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openKeyText.gameObject.SetActive(false);
        canOpen = false;
    }
}
