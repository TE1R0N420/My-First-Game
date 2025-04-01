using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponsPickup : MonoBehaviour
{
    [SerializeField] WeaponsSystem weapon;
    private bool pickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pickUp)
        {
            pickUp = true;

            bool gunOnPlayer = false;

            foreach(WeaponsSystem weaponToCheck in collision.GetComponent<PlayerController>().GetAvailableWeaponsOnPlayer())
            {
                if(weapon.GetWeaponName() == weaponToCheck.GetWeaponName())
                {
                    gunOnPlayer = true;
                }
            }

            if (!gunOnPlayer)
            {
                WeaponsSystem weaponToAdd = Instantiate(weapon, collision.GetComponent<PlayerController>().GetWeaponsArm());
                collision.GetComponent<PlayerController>().AddToAvailableWeapons(weaponToAdd);
            }

            Destroy(gameObject);
        }
    }
}
