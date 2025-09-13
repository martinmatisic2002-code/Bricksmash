using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    public float MoveSpeed;
    public float JumpSpeed;
    private int i;
    private bool IsMovingX = false;
    private bool IsMovingY = false;

    public void HorizontalMovement()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (IsMovingY == false)
                MyRigidBody.velocity = new Vector2(MoveSpeed, 0);
        }

        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (IsMovingY == false)
                MyRigidBody.velocity = new Vector2(-MoveSpeed, 0);
        }

        else if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            IsMovingY = true;
            MyRigidBody.velocity = new Vector2(0, JumpSpeed);
        }
    }

    public void VerticalLeftMovement()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (IsMovingX == false)
                MyRigidBody.velocity = new Vector2(0, -MoveSpeed);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (IsMovingX == false)
                MyRigidBody.velocity = new Vector2(0, MoveSpeed);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            IsMovingX = true;
            MyRigidBody.velocity = new Vector2(JumpSpeed, 0);
        }
    }

    public void VerticalRightMovement()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (IsMovingX == false)
                MyRigidBody.velocity = new Vector2(0, -MoveSpeed);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (IsMovingX == false)
                MyRigidBody.velocity = new Vector2(0, MoveSpeed);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            IsMovingX = true;
            MyRigidBody.velocity = new Vector2(-JumpSpeed, 0);
        }
    }

    public void UpSideDownMovement()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (IsMovingY == false)
                MyRigidBody.velocity = new Vector2(MoveSpeed, 0);
        }

        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (IsMovingY == false)
                MyRigidBody.velocity = new Vector2(-MoveSpeed, 0);
        }

        else if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            IsMovingY = true;
            MyRigidBody.velocity = new Vector2(0, -JumpSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LeftCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, -90);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 1;
        }

        else if (collision.gameObject.tag == "RightCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, 90);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 2;
        }

        else if (collision.gameObject.tag == "UpCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, 180);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 3;
        }

        else if (collision.gameObject.tag == "HorizontalCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 4;
        }
    }

    private void Update()
    {
        switch (i)
        {
            case 1:
                VerticalLeftMovement();
                break;
            case 2:
                VerticalRightMovement();
                break;
            case 3:
                UpSideDownMovement();
                break;
            case 4:
                HorizontalMovement();
                break;
        }

        if (IsMovingX == true)
        {
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        else if (IsMovingY == true)
        {
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        else
        {
            MyRigidBody.constraints = RigidbodyConstraints2D.None;
        }

    }

}
