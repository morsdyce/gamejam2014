using UnityEngine;
using System.Collections;

public class CoinsTxt : MonoBehaviour {

    private Stats stats;

	// Use this for initialization
	void Start () {
        stats = FindObjectOfType<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
        guiText.text = "Coins: " + stats.coins;
	}
}
