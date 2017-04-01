﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

    public int playerHealth1 { get; private set; }
    public int playerHealth2 { get; private set; }

    private void Start()
    {
        playerHealth1 = 5;
        playerHealth2 = 5;
    }

    void Update () {
		if(GameController.Instance.Player1.transform.position.y < -10 && playerHealth1 > 0)
        {
            playerHealth1--;
            GameController.Instance.Player1.transform.position = GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatform.transform.position;
        }
        else if(playerHealth1 == 0)
        {
            GameController.Instance.Player1.SetActive(false);
        }
        if (GameController.Instance.Player2.transform.position.y < -10)
        {
            playerHealth2--;
            GameController.Instance.Player2.transform.position = GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatform.transform.position;
        }
        else if (playerHealth2 == 0)
        {
            GameController.Instance.Player2.SetActive(false);
        }
    }
}