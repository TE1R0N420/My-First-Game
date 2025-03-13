using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] doorsToClose;
    [SerializeField] bool closeDoorOnPlayerEnter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (closeDoorOnPlayerEnter)
            {
                foreach (GameObject door in doorsToClose)
                {
                    door.SetActive(true);
                }
            }
        }
    }

}
