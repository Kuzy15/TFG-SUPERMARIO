using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private float _time;
    private int _currentAnim;
    private SpriteRenderer _renderer;

    public Sprite[] anim;
    public float animSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinMove();
        transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(0, 1), 2 * Time.deltaTime);
        StartCoroutine("DestroyCoin");
    }

    private void CoinMove()
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

    public void AddPoint()
    {

    }

    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(0.5f);
        AddPoint();
        Destroy(this.gameObject);
    }
}
