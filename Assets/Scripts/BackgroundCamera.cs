using UnityEngine;
using System.Collections;

public class BackgroundCamera : MonoBehaviour {

    public void Move(float x)
    {
        var newPosition = transform.position;
        newPosition.x = newPosition.x + x * Time.deltaTime;

        if (newPosition.x > 25.5)
        {
            newPosition.x = 0;
        }

        if (newPosition.x < 0)
        {
            newPosition.x = 25.5f;
        }

        transform.position = newPosition;


    }
}
