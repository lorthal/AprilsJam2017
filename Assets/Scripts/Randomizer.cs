﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour {

    public enum PlayerSelection
    {
        Player1,
        Player2,
        Both
    }

    public PlayerSelection playerSelected { get; private set; }

    private int tempRandom;

	// Use this for initialization
	void Start () {
        StartCoroutine(PlayerRandomizer());
	}

    IEnumerator PlayerRandomizer()
    {
        while (true)
        {
            int random = 1;
            do
            {
                tempRandom = random;
                random = Random.Range(1, 4);
                switch (random)
                {
                    case 1:
                        playerSelected = PlayerSelection.Player1;
                        break;
                    case 2:
                        playerSelected = PlayerSelection.Player2;
                        break;
                    case 3:
                        playerSelected = PlayerSelection.Both;
                        break;
                }
                Debug.Log(playerSelected);
                yield return new WaitForSeconds(0.1f);
            } while (tempRandom == random);
        }
    }
}
