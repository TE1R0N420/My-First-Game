using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class CoinPickup : MonoBehaviour
{
    [SerializeField] int coinAmount = 10;

    [SerializeField] int sfxToPlay;
    private bool pickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickUp && GetComponent<PickUpDelayer>().canBePickedUpMethod())
        {
            pickUp = true;
            
            GameManager.instance.GetBitcoins(coinAmount);
            AudioManager.instance.PlaySFX(sfxToPlay);

            Destroy(gameObject);
        }
    }
}
