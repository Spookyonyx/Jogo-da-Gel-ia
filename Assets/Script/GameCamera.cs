using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public GameManager gameManager;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, playerTransform.position.y, -10);
        }

        if (playerTransform.position.y < transform.position.y - 6)
        {

            gameManager.GameOver();
        }
    }
}



