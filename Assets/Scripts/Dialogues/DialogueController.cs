using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour, IInteractable, IResetInteraction, IInteractionPrompt
{
    public DialogueData dialogue;
    public CanvasGroup canvasGroup;
    public TMP_Animated animatedText;
    public Action OnDialogueFinished;
    private int _dialogueIndex;
    
    private enum DialogueSates { StartDialogue, NextPhrase, ExitDialogue};
    private DialogueSates _currentDialogueState;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    
    private void Start()
    {
        animatedText.onDialogueStarted.AddListener(() => CheckForDialogueFinish());
        ResetDialogueSystem();
    }

    public void Interact()
    {
        switch (_currentDialogueState)
        {
            case DialogueSates.StartDialogue:
                FadeUI(true, .2f, .65f);
                break;
            case DialogueSates.NextPhrase:
                ReadText();
                break;
            case DialogueSates.ExitDialogue:
                FadeUI(false, .2f, 0);
                ResetDialogueSystem();
                OnDialogueFinished?.Invoke();
                break;
        }
    }

    public void ResetInteraction()
    {
        ResetDialogueSystem();
    }

    private void FadeUI(bool show, float time, float delay)
    {
        Sequence s = DOTween.Sequence();
        s.AppendInterval(delay);
        s.Append(canvasGroup.DOFade(show ? 1 : 0, time));
        if (show)
        {
            s.Join(canvasGroup.transform.DOScale(0, time * 2).From().SetEase(Ease.OutBack));
            s.AppendCallback(() => ReadText());
        }
    }
    
    private void CheckForDialogueFinish()
    {
        if (_dialogueIndex < dialogue.conversationBlock.Count - 1)
        {
            _dialogueIndex++;
            _currentDialogueState = DialogueSates.NextPhrase;
        }
        else
        {
            _currentDialogueState = DialogueSates.ExitDialogue;
        }
    }

    private void ResetDialogueSystem()
    {
        canvasGroup.transform.localScale = Vector3.one;
        _dialogueIndex = 0;
        animatedText.text = string.Empty;
        _currentDialogueState = DialogueSates.StartDialogue;
        FadeUI(false, .2f, 0);
    }

    private void ReadText()
    {
        animatedText.ReadText(dialogue.conversationBlock[_dialogueIndex]);
    }
}