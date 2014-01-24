using UnityEngine;
using System.Collections;

public class NPCGroup_old : MonoBehaviour {

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

        currentTarget = new Vector3(3, 0, 0); //GetTarget();
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
        if (reachedTarget)
        {
            Debug.Log("movetotarget");
            if (Time.time >= changeTargetTime)
            {
                Debug.Log("aquire new target");
                reachedTarget = false;
                changeTargetTime = Time.time + 5f;
                
            }
        }
        else
        {
            MoveNPCs(currentTarget);
        }
    }

    void MoveNPCs(Vector3 target)
    {
        for (int i = 0, limit = npcList.Length; i < limit; i++)
        {
            var npc = npcList[i];
            var step = Vector3.MoveTowards(npc.transform.position, target, 0.1f);
            Debug.Log(step);
            npc.Move(step);

            var distance = Vector3.Distance(npc.transform.position, target);
            if (distance < 0.5)
            {
                Debug.Log("Reached Target");
                reachedTarget = true;
                currentTarget = new Vector3(-5, 0, 0);//GetTarget();
            }
        }
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
