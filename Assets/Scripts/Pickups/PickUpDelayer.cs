using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpDelayer : MonoBehaviour
{
    [SerializeField] float timeBeforePickup = 0.5f;
    private bool canBePickedUp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canBePickedUp = false;
        StartCoroutine(PickupCooldown());
    }

    IEnumerator PickupCooldown()
    {
        yield return new WaitForSeconds(timeBeforePickup);

        canBePickedUp = true;
    }

    public bool canBePickedUpMethod() { return canBePickedUp; }
}
