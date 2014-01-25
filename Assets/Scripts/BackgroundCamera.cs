using UnityEngine;
using System.Collections;

public class BackgroundCamera : MonoBehaviour {

    private Vector3 pos;
    public float baseYPosition;

    void Start ()
    {
        pos = transform.position;
        baseYPosition = pos.y;
    }

    void Update()
    {
        pos.x = Camera.main.transform.position.x % 25.5f;
        pos.y = baseYPosition + Camera.main.transform.position.y % 64.4f;
        transform.position = pos;


    }

}
