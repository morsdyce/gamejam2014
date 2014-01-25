using UnityEngine;
using System.Collections;

public class ParallaxMove : MonoBehaviour {

    public float speed = 2f;
    public float maxOffset = 1f;

    public float offset = 0.0f;
	
	// Update is called once per frame
	void Update () {

        offset += speed * Time.deltaTime;

        renderer.material.mainTextureOffset = new Vector2(offset, 0);

        if (offset >= maxOffset)
        {
            offset = -2f;
        }
	}
}
