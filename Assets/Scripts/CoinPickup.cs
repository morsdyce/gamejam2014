using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class CoinPickup : MonoBehaviour {

    public float pickupDistance = 2;
    public AudioClip clip;

    private GamePerspective persp;
    private GamePerspective playerPersp;
    private bool destroyed = false;

    void Start()
    {
        persp = GetComponent<GamePerspective>();
        playerPersp = GameObject.FindGameObjectWithTag("Player").GetComponent<GamePerspective>();
    }

    void Update()
    {
        if(GamePerspective.Distance(persp, playerPersp) <= pickupDistance && !destroyed)
        {
            audio.PlayOneShot(clip);
            FindObjectOfType<Stats>().AddCoin();
            Invoke("DestroyCoin", 0.5f);
            renderer.enabled = false;
            destroyed = true;
            
        }
    }

    void DestroyCoin()
    {
        Destroy(gameObject);
    }

}
