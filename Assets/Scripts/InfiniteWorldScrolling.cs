﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class InfiniteWorldScrolling : MonoBehaviour {

    public const float MAX_DISTANCE = 50;

    private GamePerspective scrollingCenterPersp;
    private GamePerspective persp;

	// Use this for initialization
	void Start () {
        scrollingCenterPersp = GameObject.FindGameObjectWithTag("Player").GetComponent<GamePerspective>();
        persp = GetComponent<GamePerspective>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Mathf.Abs(scrollingCenterPersp.X - persp.X) > MAX_DISTANCE)
        {
            if (scrollingCenterPersp.X > persp.X)
                persp.SetPosition(persp.X + MAX_DISTANCE * 2, persp.Z);
            else
                persp.SetPosition(persp.X - MAX_DISTANCE * 2, persp.Z);
        }
	}
}
