using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponsSystem : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    [SerializeField] float timeBetweenShots;
    private float shotCounter = 0;


    [SerializeField] Sprite weaponImage;
    [SerializeField] string weaponName;


    [SerializeField] float weaponShakeIntensity, weaponShakeTime;

    
    [SerializeField] bool isWeaponAutomatic;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FiringBullets();
    }

    private void FiringBullets()
    {
        if (GetComponentInParent<PlayerController>().PlayerIsDashing()) { return; }

        if (shotCounter > 0)
        {
            shotCounter -= Time.deltaTime;
        }

        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;

                CameraShake.instance.ShakeCamera(weaponShakeIntensity, weaponShakeTime);
            }
        }

    }

    public Sprite GetWeaponImageUI() { return weaponImage; }
    public string GetWeaponNameUI() { return weaponName; }
}
