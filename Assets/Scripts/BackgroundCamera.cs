using UnityEngine;
using System.Collections;

public class BackgroundCamera : MonoBehaviour {

    private Vector3 pos;

    void Start ()
    {
        pos = transform.position;
    }

    void Update()
    {
        pos.x = Camera.main.transform.position.x % 25.5f;
        transform.position = pos;
    }

}
