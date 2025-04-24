using UnityEngine;

public class BossController : MonoBehaviour
{

   private Transform playerToChase;
   private bool isFlipped = false;

    [SerializeField] int damageAmount = 20;
    [SerializeField] Transform pointOfAttack;

    [SerializeField] float attackRadius;
    [SerializeField] LayerMask whatIsPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerToChase = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > playerToChase.position.x && isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < playerToChase.position.x && !isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void AttackPlayer()
    {
        Collider2D playerToAttack = Physics2D.OverlapCircle(pointOfAttack.position, attackRadius, whatIsPlayer);
        print(playerToAttack);

        if(playerToAttack != null)
        {
            playerToAttack.GetComponent<PlayerHealthHandler>().DamagePlayer(damageAmount);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointOfAttack.position, attackRadius);
    }
}
