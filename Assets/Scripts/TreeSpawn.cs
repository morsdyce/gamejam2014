using UnityEngine;
using System.Collections;

public class TreeSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GamePerspective persp = GetComponent<GamePerspective>();
        persp.SetPosition(persp.X, WorldBounding.MAX_Z, 0.4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
