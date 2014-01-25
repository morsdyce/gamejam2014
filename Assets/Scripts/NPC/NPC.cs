using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class NPC : MonoBehaviour {

    private const float MIN_MOVE_DISTANCE = 1f;

    public float playerAttentionDistance = 2;
    public float speed = 10;
    public float attentionLoseSpeed = 0.5f;
    public GroupType groupType;
    private GamePerspective playerPersp;

    public float maxGroupOffset = 2;
    public float animationSpeed = 1;

    public AnimationClip idleAnim;
    public AnimationClip walkAnim;

    NPCGroup parentGroup;
    float groupOffsetX;
    float groupOffsetZ;
    GamePerspective persp;
    Animator anim;
    float attentionLost;

    Vector2 lastTarget;

    public float maxOffsetChangeTime = 10;
    public float minOffsetChangeTime = 3;
    float timeToOffsetChange;

    public float maxGroupChangeTime = 30;
    public float minGroupChangeTime = 8;
    float timeToGroupChange;

    void Start()
    {
        playerPersp = GameObject.FindGameObjectWithTag("Player").GetComponent<GamePerspective>();
        persp = GetComponent<GamePerspective>();
        anim = GetComponent<Animator>();

        anim.speed = animationSpeed;

        anim.Play(walkAnim.name);
        
        attentionLost = 0;

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
            if (groups[i].groupType == groupType)
                foundGroup = groups[i];
            i++;
            safetyTest++;
            if (i >= groups.Length)
                i = 0;
            if (safetyTest >= groups.Length + 2)
                throw new UnityException("Didn't find group");
        }
        SetParentGroup(foundGroup);
    }

    private static Vector2 _vec = new Vector2();
    void Update()
    {
        timeToOffsetChange -= Time.deltaTime;
        if (timeToOffsetChange <= 0)
            SetParentGroup(parentGroup);

        if(parentGroup.groupType != GroupType.Player)
        {
            timeToGroupChange -= Time.deltaTime;
            if (timeToGroupChange <= 0)
                FindGroup();
        }

        if (GetDistanceFromGroup() > MIN_MOVE_DISTANCE)
        {
            anim.Play(walkAnim.name);
           _vec.x = parentGroup.gamePerspective.X + groupOffsetX - persp.X;
           if (Mathf.Abs(_vec.x) > InfiniteWorldScrolling.MAX_DISTANCE)
           {
               _vec.x = InfiniteWorldScrolling.MAX_DISTANCE * 2 -_vec.x;
            }
           if (_vec.x > 0)
           {
               Vector3 scale = transform.localScale;
               scale.x = Mathf.Abs(transform.localScale.x);
               transform.localScale = scale;
           }
           else if (_vec.x < 0)
           {
               Vector3 scale = transform.localScale;
               scale.x = -Mathf.Abs(transform.localScale.x);
               transform.localScale = scale;
           }

           _vec.y = parentGroup.gamePerspective.Z + groupOffsetZ - persp.Z;
           _vec.Normalize();

            if(GetDistanceFromGroup() > MIN_MOVE_DISTANCE * 2)
                persp.Move(_vec.x * speed * (1 - attentionLost), _vec.y * speed * (1 - attentionLost));
            else
                persp.Move(_vec.x * parentGroup.speed * (1 - attentionLost), _vec.y * parentGroup.speed * (1 - attentionLost));
        }
        else if(parentGroup.groupType == GroupType.Player)
        {
            anim.Play(idleAnim.name);
        }

        if(parentGroup.groupType != GroupType.Player && GamePerspective.Distance(persp, playerPersp) <= playerAttentionDistance)
        {
            attentionLost += attentionLoseSpeed * Time.deltaTime;
            if (attentionLost > 1)
            {
                if(groupType == GroupType.Creative)
                    FindObjectOfType<Stats>().AddCreativity();
                else
                    FindObjectOfType<Stats>().RemoveCreativity();
                GoToPlayerGroup();
            }

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(transform.localScale.x);
            if (playerPersp.X < persp.X)
                scale.x *= -1;
            transform.localScale = scale;
        }
        else
        {
            attentionLost = 0;
        }
        
    }

    private void GoToPlayerGroup()
    {
        attentionLost = 0;
        SetParentGroup(playerPersp.GetComponent<NPCGroup>());
    }

    private void SetParentGroup(NPCGroup group)
    {
        if (parentGroup != group || timeToGroupChange <= 0)
            timeToGroupChange = Random.Range(minGroupChangeTime, maxGroupChangeTime);
        parentGroup = group;
        groupOffsetX = Random.Range(-maxGroupOffset, maxGroupOffset);
        groupOffsetZ = Random.Range(-maxGroupOffset, maxGroupOffset);
        timeToOffsetChange = Random.Range(minOffsetChangeTime, maxOffsetChangeTime);
    }

    private float GetDistanceFromGroup()
    {
        return GamePerspective.Distance(persp.X, persp.Z, parentGroup.gamePerspective.X + groupOffsetX, parentGroup.gamePerspective.Z + groupOffsetZ);
    }

}
