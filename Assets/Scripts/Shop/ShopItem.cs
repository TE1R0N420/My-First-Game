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
