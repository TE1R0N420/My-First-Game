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


    

    //Dashing
    private float currentMovementSpeed;
    private bool canDash;

    [SerializeField] float dashSpeed = 20f, dashLength = 0.5f, dashCooldown = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

        playerAnimator = GetComponent<Animator>();

        currentMovementSpeed = movementSpeed;

        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        PlayerPointingGunAtMouse();
        PlayerAnimating();
        //PlayerShooting();

        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            currentMovementSpeed = dashSpeed;
            canDash = false;


            playerAnimator.SetTrigger("Dash");


            StartCoroutine(DashCooldownCounter());
            StartCoroutine(DashLengthCounter());
        }

        IEnumerator DashCooldownCounter()
        {
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }

        IEnumerator DashLengthCounter()
        {
            yield return new WaitForSeconds(dashCooldown);

            currentMovementSpeed = movementSpeed;
        }



    }

    private void PlayerAnimating()
    {
        if (movementInput != Vector2.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void PlayerPointingGunAtMouse()
    {
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
    }

    

    private void PlayerMoving()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput.Normalize();

        playerRigidbody.linearVelocity = movementInput * currentMovementSpeed;
    }

    public bool PlayerIsDashing()
    {
        if (currentMovementSpeed == dashSpeed)
            return true;
        else
            return false;
    }

    //public bool isPlayerDashing() { return !canDash; }


}
