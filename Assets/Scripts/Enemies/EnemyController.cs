using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour 
{

    [SerializeField] float enemySpeed;
    private Rigidbody2D enemyRigidbody;

    [SerializeField] float playerChaseRange;
    private Vector3 directionToMoveIn;


    private Transform playerToChase;

    void Start()
    {
        playerToChase = FindAnyObjectByType<PlayerController>().transform;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, playerToChase.position) < playerChaseRange)
        {
            
        }
        
    }
        

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerChaseRange);
    }






}
