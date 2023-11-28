using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig;
    public float jumpForce;
    public float speed;

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(x * speed, rig.velocity.y);

        if (transform.position.x < -3)
        {
            transform.position += Vector3.right * 6;
        } else if (transform.position.x > 3)
        {
            transform.position += Vector3.left * 6;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rig.velocity.y < 0)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
        } 
    }
}

