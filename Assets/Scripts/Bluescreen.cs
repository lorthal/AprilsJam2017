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

    private void Start()
    {
        bluescreenEnabled = false;
    }

    private void Update()
    {
        if(GameController.Instance.Player1 == null && GameController.Instance.Player2 == null)
        {
            if (!bluescreenEnabled)
                StartCoroutine("DisplayBluescreen");
            else
            {
                if (Input.GetKeyDown(KeyCode.R))
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
        bluescreenBG.SetActive(true);
    }
}
