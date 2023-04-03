using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CorrectAnswersSO", menuName = "ScriptableObjects/CorrectAnswersObject", order = 1)]

public class CorrectAnswers : ScriptableObject
{
    [SerializeField] public List<string> answers;
}
