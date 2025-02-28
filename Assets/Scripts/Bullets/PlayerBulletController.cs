using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBulletController : MonoBehaviour 
{

    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] GameObject bulletImpactEffect;

    private Rigidbody2D bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        bulletRigidbody.linearVelocity = transform.right * bulletSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       Instantiate(bulletImpactEffect.transform, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
