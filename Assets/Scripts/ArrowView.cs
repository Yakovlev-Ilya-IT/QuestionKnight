using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowView : MonoBehaviour
{
    private Material _material;
    private float _appearProgress;

    private bool _isAppear = false;

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        QuizEventHandler.CristallSwipeBegun += Appear;
        QuizEventHandler.CristallSwipeEnded += Disappear;

        _isAppear = false;
        _material.SetFloat("_Fade", 0);
    }

    private void Appear()
    {
        _isAppear = true;
    }

    private void Disappear(Vector3 lalala)
    {
        _isAppear = false;
    }

    private void Update()
    {
        if (!_isAppear)
        {
            _appearProgress -= Time.deltaTime*2;

            if (_appearProgress <= 0)
            {
                _appearProgress = 0;
            }
        }
        else
        {
            _appearProgress += Time.deltaTime;

            if (_appearProgress >= 1)
            {
                _appearProgress = 1;
            }
        }

        _material.SetFloat("_Fade", _appearProgress);
    }


}
