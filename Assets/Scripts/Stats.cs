using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    private int _coins;
    private int _creativity;

	// Use this for initialization
	void Start () {
        _coins = 0;
        _creativity = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void AddCoin()
    {
        _coins++;
    }

    public void AddCreativity()
    {
        _creativity++;
    }

    public void RemoveCreativity()
    {
        _creativity--;
    }

    public int coins
    {
        get { return _coins; }
    }

    public int creativity
    {
        get { return _creativity; }
    }

}
