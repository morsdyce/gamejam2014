using UnityEngine;
using System.Collections;

public class collide : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("hit");
    }
}
