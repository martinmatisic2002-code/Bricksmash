using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Player_collision : MonoBehaviour
{

    public Rigidbody2D MyRigidBody;
    public BoxCollider2D MyCollider;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Granica")
        {
            MyRigidBody.gravityScale = 0;
        }
    }

}
