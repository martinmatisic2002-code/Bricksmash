using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_collision : MonoBehaviour
{

    public Rigidbody2D MyRigidBody;
    public BoxCollider2D MyCollider;
    private float PlayerPositionX;
    private float PlayerPositionY;

    private void Start()
    {
        PlayerPositionX = gameObject.transform.position.x;
        PlayerPositionY = gameObject.transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Granica")
        {
            MyRigidBody.gravityScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2)
    {
        if (collision2.gameObject.tag == "Finish")
        {
            string VictoryScreen = "Win screen";
            SceneManager.LoadScene(VictoryScreen);
        }
    }

}
