using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthAmount = 10;
    private bool pickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pickUp && GetComponent<PickUpDelayer>().canBePickedUpMethod())
        {
            pickUp = true;
            //Because two colliders react at the same time

            collision.GetComponent<PlayerHealthHandler>().AddHpToPlayer(healthAmount);
            Destroy(gameObject);
        }
    }
}
