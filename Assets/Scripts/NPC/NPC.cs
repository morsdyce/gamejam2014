using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public float attractionRatio = 1;

    float attractionAmount = 0;
    NPCGroup parentGroup;
    GamePerspective prespective;

    Vector2 lastTarget;

    void Start()
    {
        //parentGroup = (NPCGroup) gameObject.transform.parent.gameObject;
        prespective = GetComponent<GamePerspective>();
    }

    public void Move(Vector2 target)
    {
        prespective.Move(target.x, target.y);
    }

    public void React()
    {

    }

    public void setTarget(Vector2 target)
    {

    }

    public Vector2 getTarget()
    {
        lastTarget.x += 3;
        return lastTarget;
    }

    void Update()
    {
        //var target = getTarget();
        //entityMove.Move(target.x, target.y);
    }

    
}
