using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class RandomSpawnPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GamePerspective persp = GetComponent<GamePerspective>();
        GamePerspective player = GameObject.FindGameObjectWithTag("Player").GetComponent<GamePerspective>();
        persp.SetPosition(player.X + Random.Range(-InfiniteWorldScrolling.MAX_DISTANCE, InfiniteWorldScrolling.MAX_DISTANCE),
                            Random.Range(WorldBounding.MIN_Z, WorldBounding.MAX_Z));
	}

}
