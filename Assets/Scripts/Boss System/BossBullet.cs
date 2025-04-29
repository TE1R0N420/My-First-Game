using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BossBullet : MonoBehaviour
{

    [SerializeField] float speed;
    private Vector3 bulletDirection;
    [SerializeField] int bulletDamage;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletDirection = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * speed * Time.deltaTime;

        if (!FindFirstObjectByType<BossController>().gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
                collision.GetComponent<PlayerHealthHandler>().DamagePlayer(bulletDamage);

        Destroy(gameObject);
    }
}
