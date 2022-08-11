using System;
using System.Collections;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    private const string StartTransition = nameof(StartTransition);

    [SerializeField] private Animator _animator;

    private Coroutine _loadScene;

    public void LaunchTransition(Action callback)
    {
        if (_loadScene != null)
            return;

        _loadScene = StartCoroutine(LoadScene(callback));
    }

    private IEnumerator LoadScene(Action callback)
    {
        _animator.SetTrigger(StartTransition);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

        callback?.Invoke();
    }
}
