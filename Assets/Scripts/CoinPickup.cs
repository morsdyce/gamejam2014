using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamePerspective))]
public class CoinPickup : MonoBehaviour {

    public float pickupDistance = 2;

    private GamePerspective persp;
    private GamePerspective playerPersp;

    void Start()
    {
        persp = GetComponent<GamePerspective>();
        playerPersp = GameObject.FindGameObjectWithTag("Player").GetComponent<GamePerspective>();
    }

    void Update()
    {
        if(GamePerspective.Distance(persp, playerPersp) <= pickupDistance)
        {
            FindObjectOfType<Stats>().AddCoin();
            Destroy(gameObject);
        }
    }

}
