using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomPointSpawn : MonoBehaviour {

    private static Dictionary<string,  GameObject[]> spawnPoints = new Dictionary<string,GameObject[]>();
    public string tag;
    public float xOffset = 0;
    public float yOffset = 0;
    public float randXAmount = 0.2f;
    public float randYAmount = 0;

	// Use this for initialization
	void Start () {
        if(!spawnPoints.ContainsKey(tag))
            spawnPoints.Add(tag, GameObject.FindGameObjectsWithTag(tag));
        GameObject[] points = spawnPoints[tag];
        transform.position = points[Random.Range(0, points.Length)].transform.position + new Vector3(xOffset + Random.Range(-randXAmount, randYAmount), yOffset + Random.Range(-randYAmount, randXAmount), 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
