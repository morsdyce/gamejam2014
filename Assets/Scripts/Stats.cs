using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    private int _coins;

	// Use this for initialization
	void Start () {
        _coins = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void AddCoin()
    {
        _coins++;
    }

    public int coins
    {
        get { return _coins; }
    }

}
