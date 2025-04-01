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

    private bool canOpen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chestSR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            chestSR.sprite = openChestSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openKeyText.gameObject.SetActive(true);
        canOpen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openKeyText.gameObject.SetActive(false);
        canOpen = false;
    }
}
