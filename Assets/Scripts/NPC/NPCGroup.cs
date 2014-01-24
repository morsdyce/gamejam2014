using UnityEngine;
using System.Collections;

public class NPCGroup : MonoBehaviour {

    public GroupType behaviour;
    public MoveType movementType;

    public NPC[] npcList;

    public int minX;
    public int maxX;
    public int minZ;
    public int maxZ;
    public Vector2 offset;

    Vector2 currentTarget;
    bool reachedTarget;

    float changeTargetTime;

    void Start()
    {

        changeTargetTime = 0;
        
        if (npcList.Length == 0)
        {
            throw new MissingReferenceException("The group must have npcs attaached");
        }

        currentTarget = GetTarget();
    }

    void Update()
    {
        if (behaviour == GroupType.Gloomy)
        {
            MoveGloomy();
        }
    }

    void MoveGloomy()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector2 target;
        if (reachedTarget)
        {
            if (Time.time >= changeTargetTime)
            {

                reachedTarget = false;
                target = GetTarget();
                MoveNPCs(target);

                changeTargetTime = Time.time + 2;
            }
        }
        else
        {
            target = currentTarget;
            Debug.Log("target");
            Debug.Log(target);
            
            MoveNPCs(target);
        }
    }

    private Vector3 MoveNPCs(Vector3 target)
    {
        for (int i = 0, limit = npcList.Length; i < limit; i++)
        {
            var npc = npcList[i];
            //var moveAmount = target - npc.transform.position + (offset * i);
            //npc.Move(target + (offset * i));
            npc.Move(Vector3.MoveTowards(npc.transform.position, target, 1f));
            if (npc.transform.position.Equals(target))
            {
                //Debug.Log("Reached Target");
                reachedTarget = true;
            }
        }
        return target;
    }

    public void SetTarget(Vector3 target)
    {
        currentTarget = target;
    }

    public Vector3 GetTarget()
    {
        var target = new Vector3(Random.Range(minX, maxX), transform.position.y);
        Debug.Log("new Target");
        Debug.Log(target);
        return target;
        
    }



}
