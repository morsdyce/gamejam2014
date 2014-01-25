using UnityEngine;
using System.Collections;

public class BackgroundCamera : MonoBehaviour {

    private Vector3 pos;

    public float xScale = 25.5f;
    public float yScale = 64.4f;

    
    float baseYPosition;
    float baseXPosition;

    float interval = 59.2f;
    void Start ()
    {
        pos = transform.position;
        baseYPosition = pos.y;
        baseXPosition = pos.x;
    }

    void Update()
    {
        //46
        pos.x = Camera.main.transform.position.x % /*(xScale * 3)*/ interval;

        if (pos.x < -10)
            pos.x = /*xScale * 3*/ interval + pos.x;
        /*if (pos.x < -6)
        {
            pos.x = xScale * 3;
        }*/

        pos.y = baseYPosition + Camera.main.transform.position.y % yScale;
        transform.position = pos;
        

    }

}
