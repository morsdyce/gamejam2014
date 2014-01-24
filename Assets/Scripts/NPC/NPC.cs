using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class NPC : MonoBehaviour {

    private const float MIN_MOVE_DISTANCE = 1f;

    public float speed = 10;
    public GroupType groupType;

    public float maxGroupOffset = 2;
    public float animationSpeed = 1;

    float attractionAmount = 0;
    NPCGroup parentGroup;
    float groupOffsetX;
    float groupOffsetZ;
    GamePerspective persp;
    Animator anim;

    Vector2 lastTarget;

    void Start()
    {
        //parentGroup = (NPCGroup) gameObject.transform.parent.gameObject;
        persp = GetComponent<GamePerspective>();
        anim = GetComponent<Animator>();

       

        anim.speed = animationSpeed;

        if (groupType == GroupType.Creative)
        {
            anim.Play("CreativeWalk");
        }
        else
        {
            anim.Play("businessmanWalk");
        }
        

        FindGroup();
    }

    private void FindGroup()
    {
        NPCGroup[] groups = FindObjectsOfType<NPCGroup>();
        int i = Random.Range(0, groups.Length);
        NPCGroup foundGroup = null;
        int safetyTest = 0;
        while(foundGroup == null)
        {
            if (groups[i].behaviour == groupType)
                foundGroup = groups[i];
            i++;
            safetyTest++;
            if (i >= groups.Length)
                i = 0;
            if (safetyTest >= groups.Length + 2)
                throw new UnityException("Didn't find group");
        }
        parentGroup = foundGroup;
        groupOffsetX = Random.RandomRange(-maxGroupOffset, maxGroupOffset);
        groupOffsetZ = Random.RandomRange(-maxGroupOffset, maxGroupOffset);
    }

    public void Move(Vector2 target)
    {
        persp.Move(target.x, target.y);
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

    private static Vector2 _vec = new Vector2();
    void Update()
    {
        if (GetDistanceFromGroup() > MIN_MOVE_DISTANCE)
       {
           _vec.x = parentGroup.gamePerspective.X + groupOffsetX - persp.X;
           if (Mathf.Abs(_vec.x) > InfiniteWorldScrolling.MAX_DISTANCE)
           {
               //_vec.x = //-(InfiniteWorldScrolling.MAX_DISTANCE - _vec.x);
               _vec.x = InfiniteWorldScrolling.MAX_DISTANCE * 2 -_vec.x;
            }
           _vec.y = parentGroup.gamePerspective.Z + groupOffsetZ - persp.Z;
           _vec.Normalize();

           //print(_vec);
            if(GetDistanceFromGroup() > MIN_MOVE_DISTANCE * 2)
                persp.Move(_vec.x * speed, _vec.y * speed);
            else
                persp.Move(_vec.x * parentGroup.speed, _vec.y * speed);
       }
        
    }

    private float GetDistanceFromGroup()
    {
        return GamePerspective.Distance(persp.X, persp.Z, parentGroup.gamePerspective.X + groupOffsetX, parentGroup.gamePerspective.Z + groupOffsetZ);
    }

}
