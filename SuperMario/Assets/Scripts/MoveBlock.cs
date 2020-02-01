using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public Sprite[] anim;
    public Sprite disableBlock;
    private float time;
    private int currentAnim;
    public float animSpeed = 0;
    private new SpriteRenderer renderer;
    private Vector2 startPosition;

    private bool active = false;
    private bool goDown = false;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime * animSpeed;
            if (time >= 1.0f)
            {
                currentAnim++;
                time = 0;
            }

            if (currentAnim < anim.Length)
            {
                renderer.sprite = anim[currentAnim];
            }

            if (currentAnim >= anim.Length)
            {
                renderer.sprite = disableBlock;
                active = false;
            }
           
            
            
            if ((Vector2)transform.position == startPosition + new Vector2(0, 0.3f) && !goDown)
            {
                goDown = true;
            }

            if (!goDown)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition + new Vector2(0, 0.3f), 3 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, 3 * Time.deltaTime);
            }
        }

    }

    public void Activate()
    {
        active = true;

    }
}
