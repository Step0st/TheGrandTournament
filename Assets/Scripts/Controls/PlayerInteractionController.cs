using UnityEngine;
using Zenject;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    private PlayerInputReader _playerInputReader;
    private IInteractable _interactable;
    private IInteractionPrompt _interactionPrompt;

    [Inject]
    private void Construct(PlayerInputReader playerInputReader)
    {
        _playerInputReader = playerInputReader;
    }
    
    public void Awake()
    {
        _playerInputReader.OnInteract += () =>
        {
            RunInteractions();
        };
    }
    
    private void RunInteractions()
    {
        _interactable?.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.GetComponent<IInteractable>();
        
        _interactionPrompt = other.GetComponent<IInteractionPrompt>();
        if (_interactionPrompt != null)
        {
            if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUpText(_interactionPrompt.InteractionPrompt);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var resetInteraction = other.GetComponent<IResetInteraction>();
        resetInteraction?.ResetInteraction();

        _interactionPromptUI.Close();
        
        
    }
}