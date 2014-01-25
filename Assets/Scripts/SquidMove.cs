using UnityEngine;
using System.Collections;

public class SquidMove : MonoBehaviour {

    float lastActionTime;
    float interval = 3f;
    bool canMove = false;

    void Start()
    {
        lastActionTime = Time.time;
    }

    void Stop()
    {
        canMove = false;
    }

    void Move()
    {
        //var position = Vector3.Lerp(transform.position, transform.position + new Vector3(1, 0, 0), 0.1f);
        canMove = true;
    }

    void Update()
    {
        if (canMove)
            transform.position = transform.position + Vector3.right * Time.deltaTime;
    }
}
