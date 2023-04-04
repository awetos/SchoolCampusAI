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

        SetUpForNextQuestion();

        if (responses == null)
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
        responses.Add(leftButton.text);
        boomSound.Play();
        yes_button.interactable = false;
        no_button.interactable = false;
        GoToNextQuestion();

    }
    [SerializeField] TMPro.TMP_Text leftButton;
    [SerializeField] TMPro.TMP_Text rightButton;
    [SerializeField] QuestionsObject questionsList;

    void AnsweredNo()
    {
        responses.Add(rightButton.text);
        boomSound.Play();
        yes_button.interactable = false;
        no_button.interactable = false;
        GoToNextQuestion();
    }
    [SerializeField] DangerMeasurer dangerMeasurer;
    int currentQuestionNumber;
    void GoToNextQuestion()
    {
        if (responses[currentQuestionNumber] != correctAnswersRef.answers[currentQuestionNumber])
        {
            dangerMeasurer.IncreaseDanger();
        }
        if(questionsList == null)
        {
            Die();
        }
        else
        {
            currentQuestionNumber++;
            if(currentQuestionNumber >= questionsList.QuestionsText.Count)
            {
                canvas.enabled = false;
                ProcessResults();
            }
            else
            {
                SetUpForNextQuestion();
                yes_button.interactable = true;
                no_button.interactable = true;
            }
        }

       
    }

    void SetUpForNextQuestion()
    {
        leftButton.text = questionsList.Yes_text[currentQuestionNumber];
        rightButton.text = questionsList.No_text[currentQuestionNumber];
        question_text.text = questionsList.QuestionsText[currentQuestionNumber];
    }

    [SerializeField] SceneReference MainMenu;
    [SerializeField] CorrectAnswers correctAnswersRef;
    void ProcessResults()
    {
        bool AllCorrect = true;
        for(int i = 0; i < correctAnswersRef.answers.Count; i++)
        {
            Debug.Log("comparing " + responses[i] +" and " + correctAnswersRef.answers[i]);

            if (responses[i].Equals(correctAnswersRef.answers[i]))
            {
                Debug.Log("correct");
                continue;
            }
            else
            {
                Debug.Log("incorrect");
                AllCorrect = false;
            
            }
        }

        if(AllCorrect == true)
        {
            Win();
        }
        else
        {
            Die();
        }
       
        
    }

    [SerializeField] EndGame endgameptr;
    void Die()
    {
        endgameptr.OnEndGame("You have been determined to be a security threat.");
    }

    [SerializeField] GameObject winscreen;
    void Win()
    {
        winscreen.SetActive(true);
    }
    
}
