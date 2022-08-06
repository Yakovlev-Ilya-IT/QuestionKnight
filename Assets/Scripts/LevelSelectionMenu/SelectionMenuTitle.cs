using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TypeWriter))]
public class SelectionMenuTitle : MonoBehaviour
{
    [SerializeField] string _levelSelectionText;
    [SerializeField] string _adventureSelectionText;
    private TypeWriter _typeWriter;

    private ILevelSelectionMediator _mediator;

    [Inject]
    public void Construct(ILevelSelectionMediator mediator)
    {
        _mediator = mediator;
    }

    private void Awake()
    {
        _typeWriter = GetComponent<TypeWriter>();
    }

    public void SetLevelSelectionText()
    {
        _typeWriter.Write(_levelSelectionText);
    }

    public void SetAdventureSelectionText()
    {
        _typeWriter.Write(_adventureSelectionText);
    }
}
