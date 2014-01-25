using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnObject;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int maxSpawndObjects = 9999999;

    private float nextSpawnTime;
    private int objectsSpawned = 0;

	// Use this for initialization
	void Start () {
        SetNextSpawnTime();
	}
	
    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

	// Update is called once per frame
	void Update () {
	    if(Time.time >= nextSpawnTime && objectsSpawned < maxSpawndObjects)
        {
            Spawn();
            SetNextSpawnTime();
        }
	}

    private void Spawn()
    {
        GameObject.Instantiate(spawnObject);
        objectsSpawned++;
    }

}
