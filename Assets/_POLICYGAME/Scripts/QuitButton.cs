using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    [SerializeField] Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(OnClickQuitGame);
    }

    void OnClickQuitGame()
    {
        Application.Quit();
    }
}
