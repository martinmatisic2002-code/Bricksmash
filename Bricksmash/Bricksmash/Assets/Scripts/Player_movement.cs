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
    public Animator MyAnimator;
    public float MoveSpeed;
    public float JumpSpeed;
    public float VaultSpeed;
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

        if (collision.gameObject.tag == "HorizontalCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 1;
        }

        if (collision.gameObject.tag == "LeftCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, -90);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 2;
        }

        else if (collision.gameObject.tag == "RightCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, 90);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 3;
        }

        else if (collision.gameObject.tag == "UpCollider")
        {
            IsMovingX = false;
            IsMovingY = false;
            Quaternion rotation = Quaternion.Euler(0, 0, 180);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
            i = 4;
        }

    }

    private void OnTriggerExit2D(Collider2D collision2)
    {
        if (i == 1 && collision2.gameObject.tag == "HorizontalCollider")
        {
            if (MyRigidBody.velocity.x > 0)
                MyRigidBody.velocity = new Vector2(VaultSpeed, 0);

            else if (MyRigidBody.velocity.x < 0)
                MyRigidBody.velocity = new Vector2(-VaultSpeed, 0);

            else
                return;
        }

        if (i == 2 && collision2.gameObject.tag == "LeftCollider")
        {
            if (MyRigidBody.velocity.y > 0)
                MyRigidBody.velocity = new Vector2(0, VaultSpeed);

            else if (MyRigidBody.velocity.y < 0)
                MyRigidBody.velocity = new Vector2(0, -VaultSpeed);

            else
                return;
        }

        if (i == 3 && collision2.gameObject.tag == "RightCollider")
        {
            if (MyRigidBody.velocity.y > 0)
                MyRigidBody.velocity = new Vector2(0, VaultSpeed);

            else if (MyRigidBody.velocity.y < 0)
                MyRigidBody.velocity = new Vector2(0, -VaultSpeed);

            else
                return;
        }

        if (i == 4 && collision2.gameObject.tag == "UpCollider")
        {
            if (MyRigidBody.velocity.x > 0)
                MyRigidBody.velocity = new Vector2(VaultSpeed, 0);

            else if (MyRigidBody.velocity.x < 0)
                MyRigidBody.velocity = new Vector2(-VaultSpeed, 0);

            else
                return;
        }
    }

    private void MainCharacterAnimation()
    {
        if (IsMovingX || IsMovingY)
            MyAnimator.SetBool("Is_Jumping", true);

        else
            MyAnimator.SetBool("Is_Jumping", false);

        if (IsMovingX == false || IsMovingY == false)
        {
            if (MoveSpeed != 0) 
                MyAnimator.SetBool("Is_Dashing", true);
        }

        else
            MyAnimator.SetBool("Is_Dashing", false);

    }

    private void Update()
    {
        switch (i)
        {
            case 1:
                HorizontalMovement();
                break;
            case 2:
                VerticalLeftMovement();
                break;
            case 3:
                VerticalRightMovement();
                break;
            case 4:
                UpSideDownMovement();
                break;
        }

        if (IsMovingX)
        {
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            MyRigidBody.drag = 0;
        }

        else if (IsMovingY)
        {
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            MyRigidBody.drag = 0;
        }

        else
        {
            MyRigidBody.constraints = RigidbodyConstraints2D.None;
            MyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            MyRigidBody.drag = 10;
        }

        MainCharacterAnimation();

    }

}
