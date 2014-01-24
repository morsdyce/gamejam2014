using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    public float speed = 5;
    private GamePerspective persp;

	// Use this for initialization
	void Start () {

        persp = GetComponent<GamePerspective>();
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        persp.Move(dx * speed, dz * speed);
	}
}
