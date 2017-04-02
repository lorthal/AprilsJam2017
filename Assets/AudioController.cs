using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    AudioSource audio;

    private float loopStart;
    private float loopEnd;
    private float ending;
    private bool end;
    
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        loopStart = 7.693f;
        loopEnd = 28.8577f;
        ending = 70.256f;
        end = false;
        audio.Play();
	}

	void Update () {
		if(audio.time >= loopEnd && !end)
        {
            audio.time = loopStart;
        }

        if(GameController.Instance.Player1 == null && GameController.Instance.Player2 == null && !end)
        {
            end = true;
            audio.time = ending;
        }
	}
}
