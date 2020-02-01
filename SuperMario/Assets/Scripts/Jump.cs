using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool onGround = false;
    private bool maxJump = false;
    private Rigidbody2D rigidBody;
    private RaycastHit raycastDown;
    private bool directionY = false;
    public float jumpForce = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.transform.parent.GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        directionY = Input.GetButton("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JumpMove();
        if (directionY && !maxJump && onGround)
        {
            rigidBody.AddForce(new Vector2(rigidBody.velocity.x, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void JumpMove()
    {
        Debug.Log(jumpForce);


        if (directionY)
        {
            jumpForce++;
            if (jumpForce >= 7.0f)
            {
                maxJump = true;
                jumpForce = 0.0f;
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
        {
            Debug.Log("Enter");
            onGround = true;
            maxJump = false;
            jumpForce = 0.0f;
        }
    }
}
