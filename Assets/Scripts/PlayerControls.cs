using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    public float speed = 5;
    private EntityMove movement;

	// Use this for initialization
	void Start () {

        movement = GetComponent<EntityMove>();
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        movement.Move(dx * speed, dz * speed);
	}
}
