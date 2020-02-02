using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform target;

    //Si tiene un target establecido, entonces la camara se encargará de seguirle, con un determinado offset.
    void LateUpdate()
    {
        if (target)
        {
            transform.position = new Vector3(target.position.x, (target.position.y + (GetComponent<Camera>().orthographicSize/1.6f)), -1);
        }
    }
}
