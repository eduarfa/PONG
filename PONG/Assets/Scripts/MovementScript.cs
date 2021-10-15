using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D playerRB;
    public Vector3 startPosition;

    private float movement;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        playerRB.velocity = new Vector2(playerRB.velocity.x, movement * speed);
        
    }

    public void Reset()
    {
        playerRB.velocity = Vector2.zero;
        transform.position = startPosition;
    }
   
}
