using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GamePerspective))]
public class PlayerControls : MonoBehaviour {

    public float speed = 5;
    private GamePerspective persp;

    BackgroundCamera backgroundCamera;

	// Use this for initialization
	void Start () {

        persp = GetComponent<GamePerspective>();
        backgroundCamera = GameObject.FindWithTag("BackgroundCamera").GetComponent<BackgroundCamera>();
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        persp.Move(dx * speed, dz * speed);

        backgroundCamera.Move(dx * speed);
	}
}
