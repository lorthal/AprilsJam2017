using System.Collections;
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
            Vector3 respawnPosition = GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatform.transform.position;
            respawnPosition.y += 2.0f;
            GameController.Instance.Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameController.Instance.Player1.transform.position = respawnPosition;
            
        }
        else if(playerHealth1 == 0)
        {
            Destroy(GameController.Instance.Player1);
        }
        if (GameController.Instance.Player2.transform.position.y < -10)
        {
            playerHealth2--;
            Vector3 respawnPosition = GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatform.transform.position;
            respawnPosition.y += 2.0f;
            GameController.Instance.Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameController.Instance.Player2.transform.position = respawnPosition;
        }
        else if (playerHealth2 == 0)
        {
            Destroy(GameController.Instance.Player2);
        }
    }
}
