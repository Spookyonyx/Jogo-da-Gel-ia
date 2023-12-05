using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rig;
    public float jumpForce;
    public float speed;

    public TMP_Text pontuacaoText;
    public int pontos = 0;

    void Update()
    {
        if (rig.bodyType == RigidbodyType2D.Static)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(x * speed, rig.velocity.y);

        if (transform.position.x < -3)
        {
            transform.position += Vector3.right * 6;
        }
        else if (transform.position.x > 3)
        {
            transform.position += Vector3.left * 6;
        }

        if (transform.position.y > pontos)
        {
            pontos = (int)transform.position.y;
            pontuacaoText.text = "Score: " + pontos.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (rig.velocity.y < 0)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            }
        }

        if (collision.gameObject.layer == 7)
        {
            gameManager.GameOver();
        }
        if (collision.gameObject.layer == 8)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce * 1.3f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            if (rig.velocity.y < 0)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpForce * 0.52f);
                var rigfall = collision.gameObject.GetComponent<Rigidbody2D>();
                rigfall.bodyType = RigidbodyType2D.Dynamic;
            }
        }

    }

}

