using System;
using UnityEngine;

public class StartWindow : MonoBehaviour
{
    public Action NewGameEvent;

    public Action CreditsEvent;

    public Action QuitEvent;

    public void OnNewGame()
    {
        NewGameEvent?.Invoke();
    }

    public void OnCredits()
    {
        CreditsEvent?.Invoke();
    }

    public void OnGameQuit()
    {
        QuitEvent?.Invoke();
    }
}
