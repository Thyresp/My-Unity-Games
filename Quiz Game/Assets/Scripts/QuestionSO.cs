using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question",fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string question = "Enter new question here";
    [SerializeField]string[] answersArray = new string[4];
    [SerializeField]int answerIs;

    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswerIndex()
    {
        return answerIs;
    }
    public string GetAnswer(int index)
    {
        return answersArray[index];
    }
}
