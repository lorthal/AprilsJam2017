using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Start"))
            OnStartButtonClick();
        if (Input.GetButtonDown("Exit"))
            OnExitButtonClick();
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene("main");
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
