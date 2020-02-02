using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public float shift = 2;
    public float jumpSpeed = 2;
    public float velocity = 0;
    public float gravity = 1;

    public Sprite[] smallWalk;
    public Sprite[] smallIdle;
    public Sprite[] bigWalk;
    public Sprite[] bigIdle;

    private SpriteRenderer _marioSprite;
    private Sprite[] _currentAnim;
    private float _directionX = 0;
    private bool _isBig = true;
    private int _animState = 0;
    private float _animTime = 0;
    private int _currentSprite = 0;
    private Rigidbody _rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        _marioSprite = this.GetComponentInChildren<SpriteRenderer>();
        SetAnim(0, true);
        _currentAnim = bigIdle;
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _directionX = Input.GetAxis("Horizontal");

        if (_directionX < 0)
        {
            _marioSprite.flipX = true;
            SetAnim(1, true);
        }
        else if(_directionX > 0)
        {
            _marioSprite.flipX = false;
            SetAnim(1, true);
        }
        else
        {
            SetAnim(0, true);
        }
        velocity = Mathf.Lerp(velocity, _directionX, shift * Time.deltaTime);

        if(velocity < 0.000003f && velocity > -0.000003f)
        {
            velocity = 0;
        }

        Vector2 pos = this.transform.position;
        pos.x += (speed * velocity * Time.deltaTime);
        transform.position = pos;

        _animTime += Time.deltaTime * (Mathf.Abs(velocity))*(speed*2);

        if ((int)_animTime >= 1)
        {
            _animTime = 0;
            _currentSprite++;
        }

        if(_currentSprite >= _currentAnim.Length)
        {
            _currentSprite = 0;
        }
        _marioSprite.sprite = _currentAnim[_currentSprite];
      
    }

    private void FixedUpdate()
    {

    }

   

    private void SetAnim(int state, bool big)
    {
        if (_animState != state)
        {
            switch (state)
            {
                case 0:
                    if (big)
                        _currentAnim = bigIdle;
                    else
                        _currentAnim = smallIdle;
                    break;
                case 1:
                    if (big)
                        _currentAnim = bigWalk;
                    else
                        _currentAnim = smallWalk;
                    break;
            }
            _animState = state;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Block>())
        {
            collision.collider.GetComponent<Block>().ActivateBlock();
        }
    }
}
