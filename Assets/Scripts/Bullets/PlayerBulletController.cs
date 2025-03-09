using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBulletController : MonoBehaviour 
{

    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] GameObject bulletImpactEffect;
    [SerializeField] int damageAmount = 10;
    [SerializeField] GameObject []damageEffects;

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

        if (collision.CompareTag("Enemy"))
        {
            int selectedSplatter = Random.Range(0, damageEffects.Length);
            Instantiate(damageEffects[selectedSplatter], transform.position, transform.rotation);

            collision.GetComponent<EnemyController>().DamageEnemy(damageAmount);

        }
        else
        {
            Instantiate(bulletImpactEffect.transform, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
