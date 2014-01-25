using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

    public AudioClip calm;
    public AudioClip crazy;

    private Stats stats;
    int lastCreativity = 0;

    bool isPlayingCalm = false;


	// Use this for initialization
	void Start () {

        stats = FindObjectOfType<Stats>();
	}
	
	// Update is called once per frame
	void Update () {

        if (stats.creativity > 1 && isPlayingCalm && lastCreativity != stats.creativity)
        {
            print("switch to crazy");
            audio.Stop();
            audio.clip = crazy;
            audio.Play();
            isPlayingCalm = false;

        }
        else if (!isPlayingCalm && lastCreativity != stats.creativity)
        {
            print("switch to calm");
            audio.Stop();
            audio.clip = calm;
            audio.Play();
            isPlayingCalm = true;
        }

        lastCreativity = stats.creativity;
	
	}
}
