using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float moveSpeed = 3f;

    private float smoothMovement = 15f;

    private Vector3 targetForward;

    private bool canMove;

    private Vector3 deltaPos;
    private Camera mainCamera;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        targetForward = transform.forward;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateForward();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void UpdateForward()
    {
        transform.forward = Vector3.Slerp(transform.forward,targetForward,Time.deltaTime * smoothMovement); // smooth lerping from a -> b
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0)) // left click mouse button pressed
        {
            canMove = true;
        }else if (Input.GetMouseButtonUp(0)) // left click mouse button released
        {
            canMove = false;
        }
    }

    void MovePlayer()
    {
        if (canMove)
        {
            deltaPos = new Vector3(Input.GetAxisRaw(Axis.MOUSE_X),0f,Input.GetAxisRaw(Axis.MOUSE_Y));
            deltaPos.Normalize(); // normalizing the vector direction
            deltaPos *= moveSpeed * Time.fixedDeltaTime;
            deltaPos = Quaternion.Euler(0f, mainCamera.transform.eulerAngles.y, 0f) * deltaPos;
            rigidbody.MovePosition(rigidbody.position + deltaPos);
            if (deltaPos != Vector3.zero)
            {
                targetForward = Vector3.ProjectOnPlane(-deltaPos, Vector3.up); // player pos goes forward as a negative value
            }
        }
    }
}
