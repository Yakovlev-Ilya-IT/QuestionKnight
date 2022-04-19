using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class QuestionGenerator  
{
    private List<QuestionItemData> _questionItemsData;


    public QuestionGenerator(string fileName)
    {
        _questionItemsData = JsonConvert.DeserializeObject<List<QuestionItemData>>(Resources.Load($"QuestionDataFiles/{fileName}").ToString());
    }

    public QuestionItem Generate(Question question, List<Answer> answers)
    {
        if(_questionItemsData == null || _questionItemsData.Count == 0)
        {
            return null;
        }

        int questionItemDataIndex = Random.Range(0, _questionItemsData.Count);
        int answerIndex;

        List<Answer> answersBuffer = new List<Answer>(answers);
        Dictionary<AnswerLocationSide, Answer> locationSideToAnswer = new Dictionary<AnswerLocationSide, Answer>();

        question.Initialize(_questionItemsData[questionItemDataIndex].QuestionText);
        for (int i = 0; i < answers.Count; i++)
        {
            answerIndex = Random.Range(0, answersBuffer.Count);
            answersBuffer[answerIndex].Initialize(_questionItemsData[questionItemDataIndex].Answers[i].AnswerText, _questionItemsData[questionItemDataIndex].Answers[i].IsCorrect);
            locationSideToAnswer.Add(answersBuffer[answerIndex].Side, answersBuffer[answerIndex]);
            answersBuffer.RemoveAt(answerIndex);
        }

        _questionItemsData.RemoveAt(questionItemDataIndex);

        QuestionItem questionItem = new QuestionItem(question, locationSideToAnswer);

        return questionItem;
    }
}
