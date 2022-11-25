using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool isAnswering = false;
    public bool loadNextQuestion;
    public float fillFraction;
    float timerValue;
    
    [SerializeField] Image timerImage;
    void Update()
    {
        TimerUpdate();
    }
    
    public void CancelTimer()
    {
        timerValue = 0;
    }
    void TimerUpdate()
    {
        timerValue -= Time.deltaTime;
        
        if(isAnswering == false)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                loadNextQuestion = true;
                timerValue = timeToCompleteQuestion;
                timerImage.color = Color.green;
                isAnswering = true;
            }

        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                timerValue = timeToShowCorrectAnswer;
                timerImage.color = Color.white;
                isAnswering = false;
            }
        }
        Debug.Log(isAnswering +":"+  timerValue +"="+ fillFraction );
    }
}
