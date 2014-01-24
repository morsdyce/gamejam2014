using UnityEngine;
using System.Collections;

public class ParallaxMove : MonoBehaviour {

    public float speed = 2f;

    float offset = 0.0f;
	
	// Update is called once per frame
	void Update () {

        offset += speed * Time.deltaTime;
        print(offset);

        renderer.material.mainTextureOffset = new Vector2(offset, 0);

        if (offset >= 1.5f)
        {
            offset = -1.0f;
        }
	}
}
