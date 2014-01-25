using UnityEngine;
using System.Collections;

public class BaloonMove : MonoBehaviour {

    public float speed = 3f;
    public float minHeightRange = 6f;
    public float maxHeightRange = 15f;
    public float minX = -20f;
    public float maxX = 20f;
    public float minY = -2f;
    public float maxY = 2f;

    float maxHeight;
    bool canMove = true;

    void Start()
    {
        maxHeight = Random.Range(minHeightRange, maxHeightRange);

        var position = transform.position;
        position.x = Random.Range(minX, maxX);
        position.y = Random.Range(minY, maxY);

        transform.position = position;

    }
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            var position = transform.position + Vector3.up * speed * Time.deltaTime;
            transform.position = position;

            if (transform.position.y >= maxHeight)
                canMove = false;
        }
	}
}
