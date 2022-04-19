using UnityEngine;
using System.Collections.Generic;

public class QuestionItem
{
    [SerializeField] private Question _question;
    private Dictionary<AnswerLocationSide, Answer> _locationSideToAnswer;


    public QuestionItem(Question question, Dictionary<AnswerLocationSide, Answer> locationSideToAnswer)
    {
        _question = question;
        _locationSideToAnswer = locationSideToAnswer;
    }

    public Answer GetAnswer(AnswerLocationSide side)
    {
        return _locationSideToAnswer.ContainsKey(side) ? _locationSideToAnswer[side] : null;
    }
}
