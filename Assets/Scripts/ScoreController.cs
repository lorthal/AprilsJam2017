using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text player1Score;
    public Text player2Score;
    public GameObject player1;
    public GameObject player2;
    public GameObject platform;

    private int player1ScoreValue;
    private int player2ScoreValue;
    private float platformSize;
    private float playerDistance;
    private int score;

	void Start ()
    {
        player1ScoreValue = 0;
        player2ScoreValue = 0;
        player1Score.text = player1ScoreValue.ToString();
        player2Score.text = player2ScoreValue.ToString();
        platformSize = platform.GetComponent<MeshRenderer>().bounds.size.z;
        StartCoroutine(ScoreCounter());
    }

    private void OnGUI()
    {
        player1Score.text = player1ScoreValue.ToString();
        player2Score.text = player2ScoreValue.ToString();
    }

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            playerDistance = Mathf.Abs(player1.transform.position.z - player2.transform.position.z);
            score = (int)Mathf.Floor(playerDistance/platformSize);
            if(player1.transform.position.z > player2.transform.position.z)
            {
                player1ScoreValue += score;
            }
            else if(player2.transform.position.z > player1.transform.position.z)
            {
                player2ScoreValue += score;
            }
            Debug.Log("platform size: " + platformSize);
            Debug.Log("playerDistance: " + playerDistance);
            Debug.Log("score: " + score);
            yield return new WaitForSeconds(1);
        }
    }
}
