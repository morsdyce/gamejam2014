using UnityEngine;
using System.Collections;

public class GamePerspective : MonoBehaviour {

    private Vector3 pos;
    public float yRatio = 1;

    void Start()
    {
        pos = new Vector3(/*transform.localPosition.x, transform.localPosition.y, transform.localPosition.z*/);
        SetPosition(transform.localPosition.x, transform.localPosition.y);
    }

    public void SetPosition(float x, float z)
    {
        pos.x = x;
        pos.z = z;
        pos.y = pos.z;

        transform.localPosition = pos;
    }

    public float X
    {
        get { return pos.x; }
    }

    public float Z
    {
        get { return pos.z; }
    }

    public void Move(float x, float z)
    {
        SetPosition(pos.x + x * Time.deltaTime, pos.z + z * Time.deltaTime * yRatio);
    }

    public static float Distance(GamePerspective p1, GamePerspective p2)
    {
        float dx = p1.X - p2.X;
        float dz = p1.Z - p2.Z;
        return Mathf.Sqrt(dx * dx + dz * dz);
    }

}
