using UnityEngine;
using System.Collections;

public class GamePerspective : MonoBehaviour {

    private Vector3 pos;
    public float yRatio = 1;
    private float _height = 0;

    void Start()
    {
        pos = new Vector3(/*transform.localPosition.x, transform.localPosition.y, transform.localPosition.z*/);
        SetPosition(transform.localPosition.x, transform.localPosition.y);
        _height = 0;
    }

    public void SetPosition(float x, float z)
    {
        pos.x = x;
        pos.z = z;
        pos.y = pos.z + height;

        transform.localPosition = pos;
    }

    public void SetPosition(float x, float z, float height)
    {
        pos.x = x;
        pos.z = z;
        _height = height;
        pos.y = pos.z + height;

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

    public float height
    {
        get { return _height; }
    }

    public void Move(float x, float z, float height = 0)
    {
        SetPosition(pos.x + x * Time.deltaTime, pos.z + z * Time.deltaTime * yRatio, _height + height * Time.deltaTime);
    }

    public static float Distance(GamePerspective p1, GamePerspective p2)
    {
        float dx = p1.X - p2.X;
        if (Mathf.Abs(dx) > InfiniteWorldScrolling.MAX_DISTANCE)
            dx = InfiniteWorldScrolling.MAX_DISTANCE * 2 - dx;
        float dz = p1.Z - p2.Z;
        return Mathf.Sqrt(dx * dx + dz * dz);
    }

    public static float Distance(float x1, float z1, float x2, float z2)
    {
        float dx = x2 - x1;
        if (Mathf.Abs(dx) > InfiniteWorldScrolling.MAX_DISTANCE)
            dx = InfiniteWorldScrolling.MAX_DISTANCE * 2 - dx;
        float dz = z2 - z1;
        return Mathf.Sqrt(dx * dx + dz * dz);
    }

}
