using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] SceneReference StartGame;
    [SerializeField] Button StartButton;
    [SerializeField] Button QuitButton;

    // Start is called before the first frame update
    void Start()
    {

        StartButton.onClick.AddListener(OnClickStartGame);
        QuitButton.onClick.AddListener(OnClickQuit);
    }
    void OnClickStartGame()
    {
        SceneManager.LoadScene(StartGame);
    }

    void OnClickQuit()
    {
        Application.Quit();
    }
}
