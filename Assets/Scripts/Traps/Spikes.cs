using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spikes : MonoBehaviour
{
    [SerializeField] int damageAmount;
    private Collider2D playerToDamage;

    public bool shouldDamagePlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Activate Spike", true);
            playerToDamage = collision;

            shouldDamagePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Activate Spike", false);
            playerToDamage = collision;

            shouldDamagePlayer = false;
        }
    }

    public void DamagePlayer()
    {
        if (shouldDamagePlayer)
        {
            playerToDamage.GetComponent<PlayerHealthHandler>().DamagePlayer(damageAmount);
        }
    }
}
