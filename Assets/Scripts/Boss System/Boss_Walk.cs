using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss_Walking : StateMachineBehaviour
{
    Transform playerToChase;
    Rigidbody2D bossRigidBody;
    Vector3 directionToMoveIn;

    public float speed = 2.5f;
    public float attackRange = 3f;

    private float shotCounter;
    [SerializeField] float shootTime;
    
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerToChase = GameObject.FindAnyObjectByType<PlayerController>().transform;
        bossRigidBody = animator.GetComponent<Rigidbody2D>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPosition = Vector2.MoveTowards(bossRigidBody.position, playerToChase.position, speed * Time.fixedDeltaTime);
        bossRigidBody.MovePosition(newPosition);


        if(Vector2.Distance(playerToChase.position, bossRigidBody.position) < attackRange)
        {
            animator.SetTrigger("Attack");
        }

        shotCounter -= Time.fixedDeltaTime;
        if(shotCounter <= 0)
        {
            animator.SetTrigger("Shoot");
            
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Shoot");
        shotCounter = shootTime;
    }


}
