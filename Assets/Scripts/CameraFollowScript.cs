using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    private Vector3 camPos;
    
    BackgroundCamera backgroundCamera;

    public Transform target;
    public float lerpAmount = 0.25f;
    public float moveZoneX = 3.0f;
    public float moveZoneY = 0.5f;

	// Use this for initialization
	void Start () {
        camPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (target.position.x - camPos.x > moveZoneX)
        {
            camPos.x = Mathf.Lerp(camPos.x, target.position.x - moveZoneX, lerpAmount);
        }
        if (target.position.x - camPos.x < -moveZoneX)
        {
            camPos.x = Mathf.Lerp(camPos.x, target.position.x + moveZoneX, lerpAmount);
        }

        if (target.position.y - camPos.y > moveZoneY) 
            camPos.y = Mathf.Lerp(camPos.y, target.position.y - moveZoneY, lerpAmount);
        if (target.position.y - camPos.y < -moveZoneY)
            camPos.y = Mathf.Lerp(camPos.y, target.position.y + moveZoneY, lerpAmount);

        if (camPos.y < 0)
            camPos.y = 0;

        transform.position = camPos;

        

        //var backgroundCamPosition = new Vector3(target.position.x - moveZoneX, 51.82983f, 0);


	}
}
