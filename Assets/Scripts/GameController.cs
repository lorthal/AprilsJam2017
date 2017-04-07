using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameObject player1Prefab;
    public Transform player1Spawn;
    public GameObject player2Prefab;
    public Transform player2Spawn;
    public GameObject player1CamPrefab;
    public GameObject player2CamPrefab;
    public float camerasHeight = 2.0f;
    public float camerasDistance = 2.0f;
    public GameObject Player1 { get; private set; }
    public GameObject Player2 { get; private set; }
    private GameObject player1Cam;
    private GameObject player2Cam;

    private void Start ()
    {
        Instance = this;

        Player1 = Instantiate(player1Prefab, player1Spawn.position, player1Spawn.rotation);
        Vector3 player1CamSpawnPosition = player1Spawn.position + new Vector3(0.0f, camerasHeight, -camerasDistance);
        player1Cam = Instantiate(player1CamPrefab, player1CamSpawnPosition, Quaternion.identity);
        player1Cam.GetComponent<CameraFollow>().player = Player1;
        Player2 = Instantiate(player2Prefab, player2Spawn.position, player2Spawn.rotation);
        Vector3 player2CamSpawnPosition = player2Spawn.position + new Vector3(0.0f, camerasHeight, -camerasDistance);
        player2Cam = Instantiate(player2CamPrefab, player2CamSpawnPosition, Quaternion.identity);
        player2Cam.GetComponent<CameraFollow>().player = Player2;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Exit"))
            Application.Quit();
    }
}
