using System;
using System.Collections;
using System.Collections.Generic;
using Game.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private CreditsWindow _creditsWindow;

    private void Start()
    {
        _startWindow.gameObject.SetActive(true);
        _creditsWindow.gameObject.SetActive(false);

        _startWindow.QuitEvent += () => { ExitHelper.Exit(); };

        _startWindow.NewGameEvent += () =>
        {
            SceneManager.LoadScene("MainLocation");
        };

        _startWindow.CreditsEvent += () =>
        {
            _startWindow.gameObject.SetActive(false);
            _creditsWindow.gameObject.SetActive(true);
        };

        _creditsWindow.BackToMenuEvent += () =>
        {
            _creditsWindow.gameObject.SetActive(false);
            _startWindow.gameObject.SetActive(true);
        };

    }
}
