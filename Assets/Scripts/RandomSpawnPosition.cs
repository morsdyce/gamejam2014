using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class RandomSpawnPosition : MonoBehaviour {

    public GamePerspective player;

	// Use this for initialization
	void Start () {
	    GamePerspective persp = GetComponent<GamePerspective>();
        persp.SetPosition(player.X + Random.Range(-InfiniteWorldScrolling.MAX_DISTANCE, InfiniteWorldScrolling.MAX_DISTANCE),
                            Random.Range(WorldBounding.MIN_Z, WorldBounding.MAX_Z));
	}

}
