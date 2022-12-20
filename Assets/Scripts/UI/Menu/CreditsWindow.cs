using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsWindow : MonoBehaviour
{
    public Action BackToMenuEvent;

    
    public void OnMainMenu()
    {
        BackToMenuEvent?.Invoke();
    }
}
