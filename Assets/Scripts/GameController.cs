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

        Player1 = Instantiate(player1Prefab, new Vector3(1.0f,1.0f,0.0f), Quaternion.identity);
        Player2 = Instantiate(player2Prefab, new Vector3(6.0f,1.0f,0.0f), Quaternion.identity);
	}
}
