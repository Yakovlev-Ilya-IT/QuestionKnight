using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToAnswerHandler : MonoBehaviour
{
    private float _timeToAnswer;
    private float _remainigTimeToAnswer;

    [SerializeField] private StatusBar _timeBar;

    private IEnumerator _countdownForAnswer;

    public event Action TimeToAnswerIsOver;

    public void Init(float timeToAnswer)
    {
        _timeToAnswer = timeToAnswer;
        _remainigTimeToAnswer = _timeToAnswer;
        _timeBar.Init();
    }

    public void StartCountingAnswerTime()
    {
        _countdownForAnswer = CountdownForAnswer();
        StartCoroutine(_countdownForAnswer);
    }

    public void StopCountingAnswerTime()
    {
        StopCoroutine(_countdownForAnswer);
    }

    private IEnumerator CountdownForAnswer()
    {
        while (_remainigTimeToAnswer > 0)
        {
            _remainigTimeToAnswer -= Time.deltaTime;

            if(_timeBar != null)
                _timeBar.SetFilling(_remainigTimeToAnswer / _timeToAnswer);

            yield return null;
        }

        TimeToAnswerIsOver?.Invoke();
    }
}
