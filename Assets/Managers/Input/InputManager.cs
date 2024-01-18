using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager _INPUT_MANAGER;
    private PlayerActions playerInputs;

    private float timeSiceJumpPressed = 0f;
    private float timeSiceBoostPressed = 0f;
    private float rightPressed = 0f;
    private float leftPressed = 0f;
    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInputs = new PlayerActions();
            playerInputs.Character.Enable();

            playerInputs.Character.Jump.performed += JumpButtonPressed;
            playerInputs.Character.Boost.performed += BoostButtonPressed;
            playerInputs.Character.Rigth.performed += RightButtonPressed;
            playerInputs.Character.Left.performed += LeftButtonPressed;


            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {

        timeSiceJumpPressed += Time.deltaTime;
        timeSiceBoostPressed += Time.deltaTime;
        rightPressed += Time.deltaTime;
        leftPressed += Time.deltaTime;

        InputSystem.Update();
    }

    private void JumpButtonPressed(InputAction.CallbackContext context)
    {
        timeSiceJumpPressed = 0;
        Debug.Log("Salto");
    }

    private void BoostButtonPressed(InputAction.CallbackContext context) 
    {
        timeSiceBoostPressed = 0;
        Debug.Log("Boost");
    }

    private void RightButtonPressed(InputAction.CallbackContext context)
    {
        rightPressed = 0f;
        Debug.Log("D");
    }

    private void LeftButtonPressed(InputAction.CallbackContext context)
    {
        leftPressed = 0f;
        Debug.Log("A");
    }

    public float GetRightButtonPressed()
    {
        return rightPressed;
    }

    public float GetLeftButtonPressed()
    {
        return leftPressed;
    }


    public float GetJumpButtonPressed()
    {
        return timeSiceJumpPressed;
    }

    public float GetBoostButtonPressed()
    {
        return timeSiceBoostPressed;
    }

}
