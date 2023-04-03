using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Canvas EndGameCanvas;
    [SerializeField] TMPro.TMP_Text reason_text;

    [SerializeField] FirstPersonLook FPL;
    [SerializeField] FirstPersonMovement FPM;

    [SerializeField] Button returnButton;
    [SerializeField] AudioSource GunshotSound;

    private void Start()
    {
        returnButton.onClick.AddListener(ReturnToMainMenu);
    }

    [SerializeField] SceneReference MainMenu;

    void ReturnToMainMenu()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Sounds");
        Destroy(go);
        SceneManager.LoadScene(MainMenu);
    }

    // Start is called before the first frame update

    public void OnEndGame(string reason)
    {
        GunshotSound.Play();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (FPL.enabled == true)
        {
            FPL.enabled = false;
            FPM.enabled = false;
        }
        reason_text.text = reason;
        StartCoroutine("FadeIntoScene");
     
    }
    [SerializeField] CanvasGroup cg;
    IEnumerator FadeIntoScene()
    {
       
        EndGameCanvas.enabled = true;
        for (int i = 0; i < 10; i++)
        {
            cg.alpha = (float)i / (float)10f;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
