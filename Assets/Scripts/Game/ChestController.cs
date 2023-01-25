using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DialogueController))]
public class ChestController : MonoBehaviour, IInteractable, IResetInteraction
{
    [SerializeField] private Animator _chestAnim;

    [Header("Reward")] [SerializeField] private Equipment equipmentReward;

    private GameSession _session;
    private DialogueController _dialogueController;

    private void Start()
    {
        _session = FindObjectOfType<GameSession>();
        _dialogueController = GetComponent<DialogueController>();
        _dialogueController.OnDialogueFinished += StartLevelTransition;
    }

    public void Interact()
    {
        _chestAnim.SetTrigger("open");
        GiveReward();
    }

    private void StartLevelTransition()
    {
        StartCoroutine(LoadMainLocation());
    }

    IEnumerator LoadMainLocation()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainLocation");
    }

    private void GiveReward()
    {
        switch (equipmentReward)
        {
            case Equipment.DoubleJumpBoots:
                _session.Data.isDoubleJumpBoots = true;
                break;
            case Equipment.Sword:
                _session.Data.isArmed = true;
                break;
        }
    }

    private void OnDestroy()
    {
        _dialogueController.OnDialogueFinished -= StartLevelTransition;
    }

    public void ResetInteraction()
    {
        StartLevelTransition();
    }
}
