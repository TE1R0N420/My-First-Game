using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;

    [SerializeField] int movementSpeed;

    [SerializeField] Transform weaponsArm;

    private Camera mainCamera;

    private Vector2 movementInput;

    private Animator playerAnimator;


    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    [SerializeField] float timeBetweenShots;
    private float shotCounter = 0;


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput.Normalize();
        
        playerRigidbody.linearVelocity = movementInput * movementSpeed;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        
        weaponsArm.rotation = Quaternion.Euler(0, 0, angle);


        if (mousePosition.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            weaponsArm.localScale = new Vector3(-1f, -1f, 1f);
        }

        else
        {
            transform.localScale = Vector3.one;
            weaponsArm.localScale = Vector3.one;
        }

        if (movementInput != Vector2.zero)
        {
            playerAnimator.SetBool ("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

        if (Input.GetMouseButtonDown(0))
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }



    }
}
