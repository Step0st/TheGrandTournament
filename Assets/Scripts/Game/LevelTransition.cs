using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour, IInteractable, IInteractionPrompt
{
    public enum Destination
    {
        Forest,
        Mountains
    };

    [Header("Destination")] public Destination _locationToGo;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public void Interact()
    {
        GoToLocation(_locationToGo);
    }

    private void GoToLocation(Destination locationToGo)
    {
        switch (locationToGo)
        {
            case Destination.Forest:
                SceneManager.LoadScene("ForestLocation");
                break;
            case Destination.Mountains:
                SceneManager.LoadScene("MountainsLocation");
                break;
        }
    }
}
