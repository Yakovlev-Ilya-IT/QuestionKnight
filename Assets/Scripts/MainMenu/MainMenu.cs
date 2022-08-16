using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _levelSelectionButton;
    [SerializeField] private Button _exitButton;

    private ISceneLoadMediator _mediator;

    [Inject]
    private void Construct(ISceneLoadMediator mediator)
    {
        _mediator = mediator;
    }

    private void OnEnable()
    {
        _levelSelectionButton.onClick.AddListener(OnLevelSelectionButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    private void OnLevelSelectionButtonClick()
    {
        DOTween.KillAll();
        _mediator.GoToLevelSelectionMenu();
    }

    private void OnDisable()
    {
        _levelSelectionButton.onClick.RemoveListener(OnLevelSelectionButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
}
