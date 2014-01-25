using UnityEngine;
using System.Collections;

public class TreeSpawn : MonoBehaviour {

    private static GameObject[] treeSpawnPoints = null;

	// Use this for initialization
	void Start () {
        if(treeSpawnPoints == null)
            treeSpawnPoints = GameObject.FindGameObjectsWithTag("TreeGrowPoint");
        transform.position = treeSpawnPoints[Random.Range(0, treeSpawnPoints.Length)].transform.position + new Vector3(0.2f + Random.Range(-0.2f, 0.2f), 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
