using UnityEngine;
using System.Collections;

public class WallSpawn : MonoBehaviour {

    public float minHeight;
    public float maxHeight;

	// Use this for initialization
	void Start () {
        GamePerspective persp = GetComponent<GamePerspective>();
        persp.SetPosition(persp.X, WorldBounding.MAX_Z + 0.1f, Random.Range(minHeight, maxHeight));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
