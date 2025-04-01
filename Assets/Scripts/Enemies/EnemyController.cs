using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour 
{

    [SerializeField] float enemySpeed;
    private Rigidbody2D enemyRigidbody;

    [SerializeField] int enemyHealth = 100;

    [SerializeField] float playerChaseRange;
    [SerializeField] float playerKeepChaseRange;


    [SerializeField] GameObject deathSplatter;
    [SerializeField] GameObject damageEffect;

    public bool isChasing;

    private Vector3 directionToMoveIn;


    private Transform playerToChase;

    private Animator enemyAnimator;

    //Attack
    [SerializeField] bool meleeAttacker;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Transform firePosition;
    [SerializeField] float shootingRange;
    [SerializeField] float timeBetweenShots;
    private bool readyToShoot;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        playerToChase = FindAnyObjectByType<PlayerController>().transform;

        enemyAnimator = GetComponentInChildren<Animator>();
        readyToShoot = true;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, playerToChase.position) < playerChaseRange)
        {
            directionToMoveIn = playerToChase.position - transform.position;
            isChasing = true;
        }
        else if (Vector3.Distance(transform.position, playerToChase.position) < playerKeepChaseRange && isChasing) 
        {
            directionToMoveIn = playerToChase.position - transform.position;
        } 
        else
        {
            directionToMoveIn = Vector3.zero;
            isChasing = false;
        }

        directionToMoveIn.Normalize();
        enemyRigidbody.linearVelocity = directionToMoveIn * enemySpeed;

        if (directionToMoveIn != Vector3.zero)
        {
            enemyAnimator.SetBool("isWalking", true);
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);
        }

        if (playerToChase.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        if(!meleeAttacker && readyToShoot && Vector3.Distance(playerToChase.transform.position, transform.position) <shootingRange)
        {
            readyToShoot = false;
            StartCoroutine(FireEnemyProjectiles());
        }

    }
        

    IEnumerator FireEnemyProjectiles()
    {
        yield return new WaitForSeconds(timeBetweenShots);


        if (playerToChase.gameObject.activeInHierarchy)
        {
            Instantiate(enemyProjectile, firePosition.position, firePosition.rotation);
            readyToShoot = true;
        }
        
    }


    public void DamageEnemy(int damageTaken)
    {
        enemyHealth -= damageTaken;

        Instantiate(damageEffect, transform.position, transform.rotation);

        if (enemyHealth <= 0) 
        {
            Instantiate(deathSplatter, transform.position, transform.rotation);

            if (GetComponent<ItemDropper>() != null)
            {
                if (GetComponent<ItemDropper>().IsItemDropper())
                {
                    GetComponent<ItemDropper>().DropItem();
                }
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerChaseRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerKeepChaseRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }






}
