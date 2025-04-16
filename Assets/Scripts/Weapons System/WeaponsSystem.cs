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

    [SerializeField] int sfxNumberToPlay;

    [SerializeField] int weaponPrice;
    [SerializeField] Sprite weaponShopSprite;

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
                PlayWeaponSFX();

                shotCounter = timeBetweenShots;

                CameraShake.instance.ShakeCamera(weaponShakeIntensity, weaponShakeTime);
            }
        }

    }

    public void PlayWeaponSFX()
    {
        AudioManager.instance.PlaySFX(sfxNumberToPlay);
    }

    public Sprite GetWeaponImageUI() { return weaponImage; }
    public string GetWeaponName() { return weaponName; }

    public int GetWeaponPrice() { return weaponPrice; }

    public Sprite GetWeaponShopSprite() { return weaponShopSprite; }
}
