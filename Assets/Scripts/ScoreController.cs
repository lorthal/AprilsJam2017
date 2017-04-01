using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text player1Score;
    public Text player2Score;
    public GameObject platform;
    public PlayerHealthController phc;

    private int player1ScoreValue;
    private int player2ScoreValue;
    private float platformSize;
    private float playerDistance;
    private int score;
    

	void Start ()
    {
        player1ScoreValue = 0;
        player2ScoreValue = 0;
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
            if (GameController.Instance.Player1 != null && GameController.Instance.Player2 != null)
            {
                playerDistance = Mathf.Abs(GameController.Instance.Player1.transform.position.z - GameController.Instance.Player2.transform.position.z);
                score = (int)Mathf.Floor(playerDistance / platformSize);
                if (GameController.Instance.Player1.transform.position.z > GameController.Instance.Player2.transform.position.z)
                {
                    player1ScoreValue += score;
                }
                else if (GameController.Instance.Player2.transform.position.z > GameController.Instance.Player1.transform.position.z)
                {
                    player2ScoreValue += score;
                }
                
                yield return new WaitForSeconds(1);
            }
            else if(GameController.Instance.Player1 != null)
            {
                score = phc.playerHealth1;
                player1ScoreValue += score;
                yield return new WaitForSeconds(3);
            }
            else if(GameController.Instance.Player2 != null)
            {
                score = phc.playerHealth2;
                player2ScoreValue += score;
                yield return new WaitForSeconds(3);
            }
            else
            {
                StopAllCoroutines();
                yield return null;
            }
        }
    }
}
