using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CoinMovement : MonoBehaviour
{
    [Header("References")]
    private GameObject parent;
    private Rigidbody2D rb;

    [Header("Vars")]
    private bool canJump = false;
    private bool canDash = false;
    private bool isGrounded = true;
    private bool haveCoolDown = true;
    private float currentCoolDownTimer;
    private bool resetTorque;

    [SerializeField] private float coolDownTimer = 2f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float torqueForce;


    [SerializeField, Min(1)] private float rayCastLong = 1;
    private LayerMask ingoreLayerMask;
   

    private void Awake()
    {
        parent = GameObject.Find("Mondo");
        rb = GetComponent<Rigidbody2D>();
        currentCoolDownTimer = coolDownTimer;
    }

    private void Update()
    {

        if (resetTorque)
        {
            rb.angularVelocity = 0;

            if (rb.velocity.x == 0 && rb.velocity.y == 0)
            {
                resetTorque = false;
            }
        }

        Debug.DrawRay(transform.position, parent.transform.up * -1 * rayCastLong, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, parent.transform.up * -1, rayCastLong);

        if (hit.collider != null)
        {
            if (hit.transform.tag == "Ground")
            {
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
        }


        if (InputManager._INPUT_MANAGER.GetJumpButtonPressed() == 0 && isGrounded)
        {
            canJump = true;
        }

        if (InputManager._INPUT_MANAGER.GetBoostButtonPressed() == 0 && haveCoolDown)
        {
            canDash = true;
            haveCoolDown = false;
        }

        if (!haveCoolDown)
        {
            currentCoolDownTimer -= Time.deltaTime;

            if(currentCoolDownTimer <= 0)
            {
                haveCoolDown = true;
                currentCoolDownTimer = coolDownTimer;
            }
        }
    }

    private void FixedUpdate()
    {

        if (canJump)
        {
            rb.AddForce(parent.transform.up * jumpForce);
            //rb.AddForce(transform.right * jumpForce);
            canJump = false;
        }
        if (canDash)
        {
            rb.AddTorque(-torqueForce, ForceMode2D.Impulse);
            canDash = false;
        }



    }

    public void SetResetTorque()
    {
        resetTorque = true;
    }
}
