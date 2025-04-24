using UnityEngine;

public class BossController : MonoBehaviour
{

   private Transform playerToChase;
   public bool isFlipped = false;
    
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
}
