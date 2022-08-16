using UnityEngine;

public class CristallView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _energyEffect;

    public void Initialize()
    {
        _energyEffect.Play();   
    }

    public void SetPause(bool isPause)
    {
        if (isPause)
            _energyEffect.Pause();
        else
            _energyEffect.Play();
    }
}
