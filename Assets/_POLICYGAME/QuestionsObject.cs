using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestionsObject", menuName = "ScriptableObjects/QuestionsObject", order = 1)]

public class QuestionsObject : ScriptableObject
{
    [TextArea(5, 20)]

    [SerializeField] public List<string> QuestionsText;

    [SerializeField] public List<string> Yes_text;
    [SerializeField] public List<string> No_text;
}

