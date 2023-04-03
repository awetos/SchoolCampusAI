using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;

    [SerializeField] TMPro.TMP_Text question_text;
    [SerializeField] Button yes_button;
    [SerializeField] Button no_button;

    [SerializeField] List<string> questions;

    [SerializeField] List<string> responses;
    [SerializeField] AudioSource boomSound;


    private void Start()
    {
        yes_button.onClick.AddListener(AnsweredYes);
        no_button.onClick.AddListener(AnsweredNo);

        if(responses == null)
        {
            responses = new List<string>();
        }
    }
    public void StartQuestionnaire()
    {
        canvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void AnsweredYes()
    {
        responses.Add("Yes");
        boomSound.Play();
        yes_button.interactable = false;
        no_button.interactable = false;
        GoToNextQuestion();

    }

    void AnsweredNo()
    {
        responses.Add("No");
        boomSound.Play();
        yes_button.interactable = false;
        no_button.interactable = false;
        GoToNextQuestion();
    }

    int currentQuestionNumber;
    void GoToNextQuestion()
    {
        if(questions == null)
        {
            Die();
        }
        else
        {
            currentQuestionNumber++;
            if(currentQuestionNumber > questions.Count)
            {
                canvas.enabled = false;
                ProcessResults();
            }
            else
            {
                yes_button.interactable = true;
                no_button.interactable = true;
            }
        }

       
    }

    [SerializeField] SceneReference MainMenu;

    void ProcessResults()
    {
        Die();
    }

    [SerializeField] EndGame endgameptr;
    void Die()
    {
        endgameptr.OnEndGame("You have been determined to be a security threat.");
    }

    void Win()
    {

    }
    
}
