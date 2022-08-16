using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Hud : MonoBehaviour
{
    [SerializeField] Button _pauseButton;

    private IGameplayMediator _mediator;

    [Inject]
    private void Construct(IGameplayMediator mediator)
    {
        _mediator = mediator;
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        _mediator.Pause();
        _mediator.ShowPausePanel();
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
    }
}
