using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

    SpriteRenderer sprRenderer;

    public float lifeTime;
    public float creativityInfluence;
    private float timeLeft;
    private Stats stats;

	// Use this for initialization
	void Start () {
        sprRenderer = GetComponent<SpriteRenderer>();
        stats = FindObjectOfType<Stats>();
        timeLeft = lifeTime;
        print("HELLO!");
	}

    private static Color _color;
	// Update is called once per frame
	void Update () {
        float d = -creativityInfluence * stats.creativity;
        if (d < 0)
            d = 1 / (-d);
        if (d == 0)
            d = 1;
        timeLeft -= Time.deltaTime * d;
        if(timeLeft / lifeTime <= 0.1)
        {
            _color = sprRenderer.material.color;
            _color.a = timeLeft / lifeTime * 10;
            sprRenderer.material.color = _color;
        }
        if (timeLeft <= 0)
            Destroy(gameObject);
	}
}
