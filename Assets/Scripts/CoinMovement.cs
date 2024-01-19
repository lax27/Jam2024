using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CoinMovement : MonoBehaviour
{
    [Header("References")]
    private GameObject parent;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    [Header("Vars")]
    private bool canJump = false;
    private bool canDash = false;
    private bool isGrounded = true;
    private bool haveCoolDown = true;
    private float currentCoolDownTimer;
    private bool resetTorque;
    private bool rightLeft;
    private float coyoteTime;


    [SerializeField] private float coolDownTimer = 2f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float torqueForce;
    [SerializeField] private AudioClip Jumpclip;


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
        Debug.Log(rightLeft);

        if (resetTorque)
        {
           
            
            if (!rightLeft)
            {
                rb.totalTorque = rb.totalTorque + 400f;

            }
            else
            {
                rb.totalTorque = rb.totalTorque - 400f;

            }

            resetTorque = false;
        }

        if (InputManager._INPUT_MANAGER.GetRightButtonPressed() == 0)
        {
            rightLeft = false;
        }

        if (InputManager._INPUT_MANAGER.GetLeftButtonPressed() == 0)
        {
            rightLeft = true;
        }

        Debug.DrawRay(transform.position, parent.transform.up * -1 * rayCastLong, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, parent.transform.up * -1, rayCastLong);

        if (hit.collider != null)
        {
            if (hit.transform.tag == "Ground")
            {
                isGrounded = true;
                coyoteTime = 0;
            }
        }
        else
        {
            isGrounded = false;
            coyoteTime += Time.deltaTime;
        }


        if (InputManager._INPUT_MANAGER.GetJumpButtonPressed() == 0 && coyoteTime <= 0.2f)
        {
            canJump = true;
            audioSource.PlayOneShot(Jumpclip);
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
            if (!rightLeft)
            {
                rb.AddTorque(-torqueForce, ForceMode2D.Force);

            }
            else
            {
                rb.AddTorque(torqueForce, ForceMode2D.Force);

            }
            canDash = false;
        }
   


    }

    public void SetResetTorque()
    {
        resetTorque = true;
    }

    public bool GetIsRigthLeft()
    {
        return rightLeft;
    }

    public float GetCurrentCooldown()
    {
        return currentCoolDownTimer;
    }

    public float GetCoolDown()
    {
        return coolDownTimer;
    }

    public bool GetCanBoost()
    {
        return haveCoolDown;
    }
}
