using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Breakables : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            bool playerIsDashing = collision.gameObject.GetComponent < PlayerController>().PlayerIsDashing();

            if(playerIsDashing)
            GetComponent<Animator>().SetTrigger("Break");
        }
    }

    public void Destroy()
    {
      Destroy(gameObject);
    }

}
