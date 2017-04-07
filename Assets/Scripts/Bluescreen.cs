using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bluescreen : MonoBehaviour
{
    public GameObject bluescreenBG;
    public float delayBeforeBluescreen = 5.0f;
    private bool bluescreenEnabled;
    public GameObject trollWhite;
    public GameObject trollViolet;
    private ScoreController scoreController;

    private void Start()
    {
        bluescreenEnabled = false;
    }

    private void Update()
    {
        if(GameController.Instance.Player1 == null && GameController.Instance.Player2 == null)
        {
            if (!bluescreenEnabled)
            {
                scoreController = FindObjectOfType<ScoreController>();
                if (int.Parse(scoreController.player1Score.text) > int.Parse(scoreController.player2Score.text))
                    trollViolet.SetActive(true);
                else
                    trollWhite.SetActive(true);
                StartCoroutine("DisplayBluescreen");
            }
            else
            {
                if (Input.GetButtonDown("Start"))
                {
                    SceneManager.LoadScene("main");
                }

            }
        }
    }

    private IEnumerator DisplayBluescreen()
    {
        bluescreenEnabled = true;
        yield return new WaitForSeconds(delayBeforeBluescreen);
        trollViolet.SetActive(false);
        trollWhite.SetActive(false);
        FindObjectOfType<SoundButton>().soundButton.gameObject.SetActive(false);
        bluescreenBG.SetActive(true);
    }
}
