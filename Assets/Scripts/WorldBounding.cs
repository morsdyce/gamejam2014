using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class WorldBounding : MonoBehaviour {

    private GamePerspective persp;

    public const float MIN_Z = -4.9f;
    public const float MAX_Z = 2.9f;

    void Start()
    {
        persp = GetComponent<GamePerspective>();
    }

	// Update is called once per frame
	void Update () {
        if(persp.Z > MAX_Z)
            persp.SetPosition(persp.X, MAX_Z);
        if (persp.Z < MIN_Z)
            persp.SetPosition(persp.X, MIN_Z);
	}

}
