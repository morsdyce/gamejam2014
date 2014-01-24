using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GamePerspective))]
public class PlayerControls : MonoBehaviour {

    public float speed = 4;
    private GamePerspective persp;
    private Animator animator;
    private SpriteRenderer sprRenderer;

    BackgroundCamera backgroundCamera;

	// Use this for initialization
	void Start () {

        persp = GetComponent<GamePerspective>();
        animator = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        backgroundCamera = GameObject.FindWithTag("BackgroundCamera").GetComponent<BackgroundCamera>();
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        if (dx == 0 && dz == 0)
            animator.speed = 0;
        else
        {
            animator.speed = 1;
            animator.Play("PlayerWalk");
            if (dx > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(transform.localScale.x);
                transform.localScale = scale;
            }
            else if (dx < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(transform.localScale.x);
                transform.localScale = scale;
            }
        }
        
        persp.Move(dx * speed, dz * speed);

        backgroundCamera.Move(dx * speed);
	}
}
