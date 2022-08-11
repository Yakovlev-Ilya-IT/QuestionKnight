using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class TimeToAnswerHandler : MonoBehaviour, IPause
{
    private float _timeToAnswer;
    private float _remainigTimeToAnswer;

    [SerializeField] private StatusBar _timeBar;

    private IEnumerator _countdownForAnswer;

    public event Action TimeToAnswerIsOver;

    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
        _pauseHandler.Add(this);
    }

    public void Set(float timeToAnswer)
    {
        _timeToAnswer = timeToAnswer;
        _remainigTimeToAnswer = _timeToAnswer;
        _timeBar.SetFullFilling();
    }

    public void SetPause(bool isPaused)
    {
        StopCountingAnswerTime();
        if (!isPaused)
            StartCountingAnswerTime();
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
