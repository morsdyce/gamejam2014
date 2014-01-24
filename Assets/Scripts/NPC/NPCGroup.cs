using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GamePerspective))]
public class NPCGroup : MonoBehaviour {

    public GroupType groupType;
    public float speed = 5;

    public float maxChangeZTime;
    public float minChangeZTime;

    public float maxChangeSpeedTime;
    public float minChangeSpeedTime;
    public float maxSpeed = 8;
    public float minSpeed = 3;

    private GamePerspective persp;
    private float timeToChangeZ;
    private float timeToChangeSpeed;
    private float targetZ;

    void Start()
    {
        persp = GetComponent<GamePerspective>();
        ChangeY();
        ChangeSpeed();
    }

    static private Vector2 _vec = new Vector2();
    void Update()
    {
        if(groupType != GroupType.Player)
        {
            timeToChangeZ -= Time.deltaTime;
            if (timeToChangeZ <= 0)
                ChangeY();

            timeToChangeSpeed -= Time.deltaTime;
            if (timeToChangeSpeed <= 0)
                ChangeSpeed();

            _vec.x = speed;
            _vec.y = targetZ - persp.Z;
            _vec.Normalize();

            persp.Move(_vec.x * speed, _vec.y * speed);
        }   
    }

    public GamePerspective gamePerspective
    {
        get { return persp; }
    }

    private void ChangeY()
    {
        targetZ = Random.Range(WorldBounding.MIN_Z, WorldBounding.MAX_Z);
        timeToChangeZ = Random.Range(minChangeZTime, maxChangeZTime);
    }

    private void ChangeSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        timeToChangeSpeed = Random.Range(minChangeSpeedTime, maxChangeSpeedTime);
    }

}
