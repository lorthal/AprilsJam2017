using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject Player1 { get; private set; }
    public GameObject Player2 { get; private set; }

    private void Start ()
    {
        Instance = this;

        Player1 = Instantiate(player1Prefab, Vector3.zero, Quaternion.identity);
        Player2 = Instantiate(player2Prefab, Vector3.zero, Quaternion.identity);
	}
}
