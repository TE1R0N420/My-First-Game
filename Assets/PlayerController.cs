using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;

    [SerializeField] int movementSpeed;

    private Vector2 movementInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       movementInput.x = Input.GetAxisRaw("Horizontal");
       movementInput.y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(movementInput.x, movementInput.y, 0f) * movementSpeed * Time.deltaTime;
        playerRigidbody.linearVelocity = movementInput * movementSpeed;
    }
}
