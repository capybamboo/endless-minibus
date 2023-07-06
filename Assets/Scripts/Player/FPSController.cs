using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 4f;
    public float runSpeed = 6f;
    public float jumpPower = 4f;
    public float gravity = 15f;

    public float lookSpeed = 2f;
    public float lookXLimit = 70f;


    Vector3 moveDirection = Vector3.zero;
    private float _rotationX = 0;

    public bool canMove = true;
    public bool canSprint = false;
    public bool canJump = false;
    

    CharacterController characterController;
    void Start()
    {
        if (PlayerPrefs.HasKey("CanMove"))
        {
            canMove = Convert.ToBoolean(PlayerPrefs.GetInt("CanMove"));
        }
        else
        {
            PlayerPrefs.SetInt("CanMove", 1);

            canMove = Convert.ToBoolean(PlayerPrefs.GetInt("CanMove"));
        }

        if (PlayerPrefs.HasKey("CanSprint"))
        {
            canSprint = Convert.ToBoolean(PlayerPrefs.GetInt("CanSprint"));
        }
        else
        {
            PlayerPrefs.SetInt("CanSprint", 0);

            canSprint = Convert.ToBoolean(PlayerPrefs.GetInt("CanSprint"));
        }

        if (PlayerPrefs.HasKey("CanJump"))
        {
            canJump = Convert.ToBoolean(PlayerPrefs.GetInt("CanJump"));
        }
        else
        {
            PlayerPrefs.SetInt("CanJump", 0);

            canJump = Convert.ToBoolean(PlayerPrefs.GetInt("CanJump"));
        }

        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("CanMove")) != canMove)
        {
            canMove = Convert.ToBoolean(PlayerPrefs.GetInt("CanMove"));
        }


        if (Convert.ToBoolean(PlayerPrefs.GetInt("CanSprint")) != canSprint)
        {
            canSprint = Convert.ToBoolean(PlayerPrefs.GetInt("CanSprint"));
        }


        if (Convert.ToBoolean(PlayerPrefs.GetInt("CanJump")) != canJump)
        {
            canJump = Convert.ToBoolean(PlayerPrefs.GetInt("CanJump"));
        }

        if (1 + PlayerPrefs.GetFloat("MouseSpeed") * 2 != lookSpeed)
        {
            lookSpeed = 1 + PlayerPrefs.GetFloat("MouseSpeed") * 2;
        }
        Debug.Log(lookSpeed);

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftControl) && canSprint;
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && canJump)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
}