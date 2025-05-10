using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Canvas canvasMessage;
    private bool inBuyZone = false;


    enum ItemType { healthRestore, healthUpgrade, weapon }
    [SerializeField] ItemType itemType;

    [SerializeField] int itemCost;

    [SerializeField] WeaponsSystem[] thePotentialWeaponsToBuy;
    private WeaponsSystem weaponToBuy;

    [SerializeField] SpriteRenderer weaponSpriteRenderer;
    [SerializeField] TMPro.TextMeshProUGUI priceText;

    private void Start()
    {
        if(itemType == ItemType.weapon)
        {
            int selectWeapon = Random.Range(0, thePotentialWeaponsToBuy.Length);
            weaponToBuy = thePotentialWeaponsToBuy[selectWeapon];

            itemCost = weaponToBuy.GetWeaponPrice();
            weaponSpriteRenderer.sprite = weaponToBuy.GetWeaponShopSprite();

            priceText.text = "Buy " + weaponToBuy.GetWeaponName() + ": " + itemCost + "BTC";
        }
    }


    private void Update()
    {
        if (inBuyZone)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if(GameManager.instance.GetCurrentBitcoins() >= itemCost)
                {
                    GameManager.instance.SpendBitcoins(itemCost);

                    switch (itemType)
                    {
                        case ItemType.healthRestore:
                            Object.FindFirstObjectByType<PlayerHealthHandler>().AddHpToPlayer(10);
                            break;

                        case ItemType.healthUpgrade:
                            Object.FindFirstObjectByType<PlayerHealthHandler>().IncreaseMaxHealth(10);
                            break;

                        case ItemType.weapon:
                            PlayerController playerBuying = Object.FindFirstObjectByType<PlayerController>();
                            WeaponsSystem weaponToAdd = Instantiate(weaponToBuy, playerBuying.GetWeaponsArm());
                            playerBuying.AddToAvailableWeapons(weaponToAdd);
                            break;

                        default:
                            Debug.Log("No item type was chosen");
                            break;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvasMessage.gameObject.SetActive(true);
        inBuyZone = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        canvasMessage.gameObject.SetActive(false);
        inBuyZone = false;
    }
}
