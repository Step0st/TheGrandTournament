using System;
using System.Collections;
using System.Collections.Generic;
using Game.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private PauseWindow _pauseWindow;
    [Inject] private PlayerInputReader _playerInputReader;

    private void Start()
    {
        //_playerInputReader = new PlayerInputReader();
        _pauseWindow.gameObject.SetActive(false);
    
        _pauseWindow.ContinueEvent += () =>
        {
            _pauseWindow.gameObject.SetActive(false);
            Time.timeScale = 1;
        };

        _pauseWindow.ToMainMenuEvent += () =>
        {
            SceneManager.LoadScene("MainMenu");
        };

        _playerInputReader.OnMenuButtonPressed += () =>
        {
            _pauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        };
    }
}
