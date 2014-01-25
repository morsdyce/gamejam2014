using UnityEngine;
using System.Collections;

public class SquidMove : MonoBehaviour {

    float interval = 3f;
    bool canMove = false;
    float startMoveTime;

    GamePerspective persp;

    void Start()
    {
        persp = GetComponent<GamePerspective>();
        persp.Move(0, 0, Random.Range(0, 10));
    }

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
        {
            persp.Move( -easeFunc(Time.time - startMoveTime, 0, 30, 3f), 0);
        }
    }

    float easeFunc(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        if ((t /= d / 2) < 1)
            return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
        return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
    }

}
