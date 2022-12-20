using System;
using System.Collections;
using System.Collections.Generic;
using Game.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private PauseWindow _pauseWindow;

    private void Start()
    {
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
