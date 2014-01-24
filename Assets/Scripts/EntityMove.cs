using UnityEngine;
using System.Collections;

public class EntityMove : MonoBehaviour {

    private Vector3 pos;
    public float yRatio = 1;

    void Start()
    {
        pos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    public void SetPosition(float x, float z)
    {
        pos.x = x;
        pos.z = z;
        pos.y = pos.z * yRatio;

        transform.localPosition = pos;
    }

    public void Move(float x, float z)
    {
        SetPosition(pos.x + x * Time.deltaTime, pos.z + z * Time.deltaTime);
    }
}
