using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CoinMovement : MonoBehaviour
{
    private bool canJump = false;
    private bool canDash = false;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float torqueForce;
    private GameObject parent;
   

    private void Awake()
    {
        parent = GameObject.Find("Mondo");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (InputManager._INPUT_MANAGER.GetJumpButtonPressed() == 0)
        {
            canJump = true;
        }

        if (InputManager._INPUT_MANAGER.GetBoostButtonPressed() == 0)
        {
            canDash = true;
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
}
