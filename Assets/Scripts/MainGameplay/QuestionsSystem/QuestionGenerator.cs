using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class QuestionGenerator  
{
    private List<QuestionItemData> _questionItemsData;

    public QuestionGenerator(string fileName)
    {
        _questionItemsData = JsonConvert.DeserializeObject<List<QuestionItemData>>(Resources.Load($"QuestionDataFiles/{fileName}").ToString());
    }

    public QuestionItem Generate(QuizItemHolder quizItemHolder)
    {
        if(_questionItemsData == null || _questionItemsData.Count == 0)
        {
            return null;
        }

        int questionItemDataIndex = Random.Range(0, _questionItemsData.Count);
        int answerIndex;

        List<Answer> answersBuffer = new List<Answer>(quizItemHolder.Answers);
        Dictionary<AnswerLocationSide, Answer> locationSideToAnswer = new Dictionary<AnswerLocationSide, Answer>();

        quizItemHolder.Question.UpdateInformation(_questionItemsData[questionItemDataIndex].QuestionText);
        for (int i = 0; i < quizItemHolder.Answers.Count; i++)
        {
            answerIndex = Random.Range(0, answersBuffer.Count);
            answersBuffer[answerIndex].UpdateInformation(_questionItemsData[questionItemDataIndex].Answers[i].AnswerText, _questionItemsData[questionItemDataIndex].Answers[i].IsCorrect);
            locationSideToAnswer.Add(answersBuffer[answerIndex].Side, answersBuffer[answerIndex]);
            answersBuffer.RemoveAt(answerIndex);
        }

        _questionItemsData.RemoveAt(questionItemDataIndex);

        QuestionItem questionItem = new QuestionItem(quizItemHolder.Question, locationSideToAnswer);

        return questionItem;
    }
}
