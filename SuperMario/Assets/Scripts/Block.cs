using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private float _time;
    private int _currentAnim;
    private SpriteRenderer _renderer;
    private Vector2 _startPosition;
    private bool _active = false;
    private bool _disable = false;
    private bool _goDown = false;
    private bool _dropped = false;

    public Sprite[] anim;
    public Sprite disableBlock;
    public float animSpeed = 0;
    public GameObject entity;



    // Start is called before the first frame update
    void Start()
    {
        _startPosition = this.transform.position;
        _renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_disable)
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
        }        
        MoveBlock();
    }

    public void ActivateBlock()
    {
        if (!_dropped)
        {
            InstantiateEntity();
            _dropped = true;
            _active = true;
        }
    }


    private void MoveBlock()
    {
        if (_active)
        {
            _disable = true;
            if ((Vector2)transform.position == _startPosition + new Vector2(0, 0.3f) && !_goDown)
            {
                _goDown = true;
            }

            if (!_goDown)
            {
                transform.position = Vector2.MoveTowards(transform.position, _startPosition + new Vector2(0, 0.3f), 3 * Time.deltaTime);
                _renderer.sprite = disableBlock;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _startPosition, 3 * Time.deltaTime);
                if ((Vector2)transform.position == _startPosition)
                {
                    _active = false;
                }
            }
        }
    }

    private void InstantiateEntity()
    {
        Instantiate(entity, (Vector2)transform.position + new Vector2(0, 1.0f), Quaternion.identity);
    }
}
