using UnityEngine;
using System.Collections;

public class DragonAnimation : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AfterAppear()
    {
        anim.Play("DragonLoop");
    }
}
