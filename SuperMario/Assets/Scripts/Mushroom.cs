using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private float _time;
    private int _currentAnim;
    private SpriteRenderer _renderer;
    private Vector2 _startPosition;
    private int _dir = 1;
    private Rigidbody2D _rigidbody;

    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = this.GetComponent<SpriteRenderer>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveMushroom();
    }

    private void MoveMushroom()
    {
        transform.Translate(_dir * Time.deltaTime * speed, 0, 0);
        //_rigidbody.velocity = new Vector2 (_dir * speed, 0);
    }

    /*private void AnimMushroom()
    {
        _time += Time.deltaTime * animSpeed;
        if (_time >= 1.0f)
        {
            _currentAnim++;
            _time = 0;
        }

        if (_currentAnim < anim.Length)
        {
            _renderer.sprite = anim[_currentAnim];
        }
        else
        {
            _currentAnim = 0;
        }
    }*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Growup
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Barrier")
        {
            _dir *= -1;
        }
    }
}
