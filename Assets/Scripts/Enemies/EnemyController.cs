using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour 
{

    [SerializeField] float enemySpeed;
    private Rigidbody2D enemyRigidbody;

    [SerializeField] int enemyHealth = 100;



    //enemies that chase the player
    [SerializeField] bool shouldChasePlayer;
    [SerializeField] float playerChaseRange;
    [SerializeField] float playerKeepChaseRange;


    [SerializeField] GameObject deathSplatter;
    [SerializeField] GameObject damageEffect;

    private bool isChasing;

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


    //enemies that run away
    [SerializeField] bool shouldRunAway;
    [SerializeField] float runawayRange;

    //enemies that wander
    [SerializeField] bool shouldWander;
    [SerializeField] float wanderLength, pauseLength;

    private float wanderCounter, pauseCounter;
    private Vector3 wanderDirection;


    //enemies that patrol
    [SerializeField] bool shouldPatrol;
    [SerializeField] Transform[] patrolPoints;
    private int currentPatrolPoint;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        playerToChase = FindAnyObjectByType<PlayerController>().transform;

        enemyAnimator = GetComponentInChildren<Animator>();
        readyToShoot = true;

        if (shouldWander)
        {
            pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);
        }
    }


    void Update()
    {
        float distancePlayerEnemy = Vector3.Distance(transform.position, playerToChase.position);


        if (distancePlayerEnemy < playerChaseRange && shouldChasePlayer)
        {
            directionToMoveIn = playerToChase.position - transform.position;
            isChasing = true;
        }
        else if (distancePlayerEnemy < playerKeepChaseRange && isChasing && shouldChasePlayer) 
        {
            directionToMoveIn = playerToChase.position - transform.position;
        } 
        else
        {
            directionToMoveIn = Vector3.zero;
            isChasing = false;
        }


        if (shouldWander && !isChasing)
        {
            if(wanderCounter > 0)
            {
                wanderCounter -= Time.deltaTime;

                directionToMoveIn = wanderDirection;

                if (wanderCounter <= 0)
                {
                    pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);
                }
            }

            if(pauseCounter > 0)
            {
                pauseCounter -= Time.deltaTime;

                if(pauseCounter <= 0)
                {
                    wanderCounter = Random.Range(wanderLength * 0.75f, wanderLength * 1.25f);
                    wanderDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                }
            }
        }


        if (shouldPatrol && !isChasing)
        {
            directionToMoveIn = patrolPoints[currentPatrolPoint].position - transform.position;
            float distanceEnemyPoint = Vector3.Distance(transform.position, patrolPoints[currentPatrolPoint].position);

            if(distanceEnemyPoint < 0.2f)
            {
                currentPatrolPoint++;
                if(currentPatrolPoint >= patrolPoints.Length)
                    currentPatrolPoint = 0;
            }
        }




        if(shouldRunAway && distancePlayerEnemy < runawayRange)
        {
            directionToMoveIn = transform.position - playerToChase.position;
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

        if (shouldChasePlayer)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerChaseRange);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, playerKeepChaseRange);
        }
        
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

        if (shouldRunAway)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, runawayRange);
        }
    }






}
