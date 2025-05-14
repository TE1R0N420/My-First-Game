using UnityEngine;

public class BossController : MonoBehaviour
{

   private Transform playerToChase;
   private bool isFlipped = false;

    [SerializeField] int damageAmount = 20;
    [SerializeField] Transform pointOfAttack;

    [SerializeField] float attackRadius;
    [SerializeField] LayerMask whatIsPlayer;

    [SerializeField] int angryDamageAmount = 40;
    [SerializeField] float angryAttackRadius;

    [SerializeField] Transform[] shootingPoints;
    [SerializeField] Transform[] angryShootingPoints;

    [SerializeField] GameObject bossBullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerToChase = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerToChase == null)
        {
            PlayerController foundPlayer = FindFirstObjectByType<PlayerController>();
            if (foundPlayer != null)
            {
                playerToChase = foundPlayer.transform;
            }
            else
            {
                return; // No player found, skip this frame
            }
        }

        if (transform.position.x > playerToChase.position.x && isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < playerToChase.position.x && !isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }


    public void AttackPlayer()
    {
        Collider2D playerToAttack = Physics2D.OverlapCircle(pointOfAttack.position, attackRadius, whatIsPlayer);
       

        if(playerToAttack != null)
        {
            playerToAttack.GetComponent<PlayerHealthHandler>().DamagePlayer(damageAmount);
        }
    }


    public void AngryAttackPlayer()
    {
        Collider2D playerToAttack = Physics2D.OverlapCircle(pointOfAttack.position, angryAttackRadius, whatIsPlayer);
        

        if (playerToAttack != null)
        {
            playerToAttack.GetComponent<PlayerHealthHandler>().DamagePlayer(angryDamageAmount);
        }
    }

    public void ShootingPlayer()
    {
        foreach(Transform point in shootingPoints)
        {
            Instantiate(bossBullet, point.position, point.rotation);
        }
    }

    public void AngryShootingPlayer()
    {
        foreach (Transform point in angryShootingPoints)
        {
            Instantiate(bossBullet, point.position, point.rotation);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (Camera.current == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointOfAttack.position, attackRadius);
    }
}
