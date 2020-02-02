using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool _onGround = false;
    private bool _maxJump = false;
    private Rigidbody2D _rigidBody;
    private bool _directionY = false;


    public float jumpForce = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = this.transform.parent.GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        _directionY = Input.GetButton("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JumpMove();
    }

    private void JumpMove()
    {
        if (_directionY)
        {
            jumpForce++;
            if (jumpForce >= 7.0f)
            {
                _directionY = false;
                _maxJump = true;
                jumpForce = 0.0f;
            }
        }

        if (_directionY && !_maxJump && _onGround)
        {
            _rigidBody.AddForce(new Vector2(_rigidBody.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
        {
            _onGround = true;
            _maxJump = false;
            jumpForce = 0.0f;
        }
    }
}
