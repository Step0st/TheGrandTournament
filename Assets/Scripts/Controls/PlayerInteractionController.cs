using UnityEngine;
using Zenject;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    private PlayerInputReader _playerInputReader;
    private IInteractable[] _interactable;
    private IResetInteraction[] _resets;
    private IInteractionPrompt _interactionPrompt;

    [Inject]
    private void Construct(PlayerInputReader playerInputReader)
    {
        _playerInputReader = playerInputReader;
    }
    
    public void Awake()
    {
        _playerInputReader.OnInteract += RunInteractions;
    }
    
    private void RunInteractions()
    {
        foreach (var interactable in _interactable)
        {
            interactable?.Interact();
        }
    }
    
    private void ResetInteractions()
    {
        foreach (var resetInteraction in _resets)
        {
            resetInteraction?.ResetInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.GetComponents<IInteractable>();
        _resets = other.GetComponents<IResetInteraction>();
        
        _interactionPrompt = other.GetComponent<IInteractionPrompt>();
        if (_interactionPrompt != null)
        {
            if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUpText(_interactionPrompt.InteractionPrompt);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _interactable = null;
        ResetInteractions();
        _interactionPromptUI.Close();
    }

    private void OnDisable()
    {
        _playerInputReader.OnInteract -= RunInteractions;
    }
}