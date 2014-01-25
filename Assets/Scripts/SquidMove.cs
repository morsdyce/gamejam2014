using UnityEngine;
using System.Collections;

public class SquidMove : MonoBehaviour {

    float interval = 3f;
    bool canMove = false;
    float startMoveTime;

    void StopSquid()
    {
        canMove = false;
    }

    void MoveSquid()
    {
        //var position = Vector3.Lerp(transform.position, transform.position + new Vector3(1, 0, 0), 0.1f);
        canMove = true;
        startMoveTime = Time.time;
    }

    void Update()
    {
        if (canMove)
            transform.position = transform.position + Vector3.right * Time.deltaTime * (Time.time - startMoveTime) * (Time.time - startMoveTime) * 3;
    }
}
