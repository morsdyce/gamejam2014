using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnObject;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int maxSpawndObjects = 9999999;
    public float creativeInfluence = 0;

    private float nextSpawnTime;
    private int objectsSpawned = 0;

    private Stats stats;

	// Use this for initialization
	void Start () {
        stats = FindObjectOfType<Stats>();
        SetNextSpawnTime();
	}
	
    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

	// Update is called once per frame
	void Update () {
        nextSpawnTime += Time.deltaTime - Time.deltaTime * Mathf.Clamp(creativeInfluence * stats.creativity, 0, float.MaxValue);
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
