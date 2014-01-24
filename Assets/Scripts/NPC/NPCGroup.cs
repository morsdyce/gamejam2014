using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GamePerspective))]
public class NPCGroup : MonoBehaviour {

    public GroupType groupType;
    public float speed = 5;

    private GamePerspective persp;

    void Start()
    {
        persp = GetComponent<GamePerspective>();
    }

    void Update()
    {
        if(groupType != GroupType.Player)
        {
            persp.Move(speed, 0);
        }   
    }

    public GamePerspective gamePerspective
    {
        get { return persp; }
    }

}
