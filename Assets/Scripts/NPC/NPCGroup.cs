using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCGroup : MonoBehaviour {

    public GroupType behaviour;
    public MoveType movementType;
    public GameObject npcPrefab;

    public int NpcCount;

    public float offsetAngle = 1.5f;
    int startAngle = 0;
    private int angleIncrease = 0;
    public bool isGoingRight = true;
    private List<NPC> npcList;

    void Start()
    {
        npcList = new List<NPC>();

        angleIncrease = 360 / NpcCount;
        for (var i = 0; i < NpcCount; i++)
        {
            var pos = GetAngle(transform.position, offsetAngle);
            // make the object face the center
            var rot = Quaternion.FromToRotation(Vector3.forward, transform.position - pos);
            var npc = (GameObject) Instantiate(npcPrefab, pos, Quaternion.identity);
            var npcScript = npc.GetComponent<NPC>();
            Debug.Log(npc);
            npcList.Add(npcScript);
        }
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
        MoveNPCs();
        
    }

    void MoveNPCs()
    {
        for (int i = 0, limit = npcList.Count; i < limit; i++)
        {
            var npc = npcList[i];
            var newPosition = npc.transform.position + new Vector3(1,0,0);
            npc.Move(newPosition);
        }
    }

    Vector3 GetAngle(Vector3 center, float radius) {
    // create random angle between 0 to 360 degrees
    startAngle += angleIncrease;
    var pos = new Vector3();
    pos.x = center.x + radius * Mathf.Sin(startAngle * Mathf.Deg2Rad);
    pos.y = center.y + radius * Mathf.Cos(startAngle * Mathf.Deg2Rad);
    pos.z = center.z;
    return pos;
}

  



}
