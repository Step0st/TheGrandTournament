using System;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    public Action ContinueEvent;

    public Action ToMainMenuEvent;

    public void OnContinue()
    {
        ContinueEvent?.Invoke();
    }
    
    public void OnMainMenu()
    {
        ToMainMenuEvent?.Invoke();
    }
}
