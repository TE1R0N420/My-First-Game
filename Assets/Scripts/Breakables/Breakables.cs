using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Breakables : MonoBehaviour
{
    [SerializeField] GameObject[] brokenParts;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            bool playerIsDashing = collision.gameObject.GetComponent < PlayerController>().PlayerIsDashing();

            if(playerIsDashing)
            {
                GetComponent<Animator>().SetTrigger("Break");

                for(int i = 0; i < brokenParts.Length; i++)
                {
                    int randomBrokenPart = Random.Range(0, brokenParts.Length);
                    Instantiate(brokenParts[randomBrokenPart], transform.position, transform.rotation);
                }

                
            }
            
        }
    }

    public void Destroy()
    {
    
        Destroy(gameObject);
    }

}
