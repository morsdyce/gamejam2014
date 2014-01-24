using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnObject;
    public float minSpawnTime;
    public float maxSpawnTime;

    private float nextSpawnTime;

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
	    if(Time.time >= nextSpawnTime)
        {
            Spawn();
            SetNextSpawnTime();
        }
	}

    private void Spawn()
    {
        GameObject.Instantiate(spawnObject);
    }

}
