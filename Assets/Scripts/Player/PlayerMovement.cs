using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Transform playerTransform;
    private Vector2 direction;

    private float mSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        //Intialize variables.
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("SlowMovement")) { mSpeed = 1.5f; } else { mSpeed = 2.5f; }
        playerRB.MovePosition((Vector2)playerTransform.position + (direction.normalized * mSpeed * Time.deltaTime));
    }
}
