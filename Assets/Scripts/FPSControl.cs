﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;
    public float jumpHeight = 5;

    private Vector3 speed;
    private float forwardSpeed;
    private float sideSpeed;

    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;

    private float verticalVelocity = 0f;


    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        FPMove();
        FPRotate();
    }


    //Player의 x축, z축 움직임을 담당
    void FPMove()
    {
        if (cc.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        //점프 기능
        if (cc.isGrounded && Input.GetButtonDown("Jump")) {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);

        // 천장에 닿으면 다시 떨어지게 한다.
        if ((cc.collisionFlags & CollisionFlags.Above) != 0)
        {
            if (verticalVelocity > 0) verticalVelocity = 0;
        }
    }

    //Player의 회전을 담당
    void FPRotate()
    {
        //좌우 회전
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
