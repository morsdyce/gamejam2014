using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GamePerspective))]
public class PlayerControls : MonoBehaviour {

    public AnimationClip walkAnim;
    public AnimationClip standAnim;
    public AnimationClip climbAnim;

    public float speed = 4;
    private GamePerspective persp;
    private Animator animator;

    public float wallClimbDistance = 0.4f;

	// Use this for initialization
	void Start () {

        persp = GetComponent<GamePerspective>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        
        if (dx == 0 && dz == 0)
        {
            if(persp.height == 0)
                animator.Play(standAnim.name);
        }
        else
        {
            if (persp.height == 0)
                animator.Play(walkAnim.name);
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

        //print((Mathf.Abs(WorldBounding.MAX_Z - persp.Z) <= wallClimbDistance) + "   " + dz);
        if(Mathf.Abs(WorldBounding.MAX_Z - persp.Z) <= wallClimbDistance && dz > 0)
        {
            persp.Move(0, 0, dz * 5);
        }
        else if(persp.height > 0)
        {
            persp.Move(0, 0, -7);
            if (persp.height < 0)
                persp.SetPosition(persp.X, persp.Z, 0);
        }

        if (persp.height > 0)
            animator.Play(climbAnim.name);

        persp.Move(dx * speed, dz * speed);
	}
}
