using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class ChestController : MonoBehaviour, IInteractable, IInteractionPrompt
    {

        [SerializeField] private Animator _chestAnim;
        
        [Header("Reward")] 
        [SerializeField] private Equipment EquipmentReward;

        [SerializeField] private string _prompt;
        public string InteractionPrompt => _prompt;
        private void Update()
        {
            /*if (Input.GetKeyDown("e") && _chestFlag)
            {
                if (rewardType == Reward.DoubleJumpBoots)
                {
                    _playerData.DoubleJump = true;
                    StartCoroutine(LoadMainLocation());
                    SetText(_mText,"You've found a Double Jump Boots");
                }
                
                if (rewardType == Reward.Sword)
                {
                   _playerData.IsArmed = true;
                   StartCoroutine(LoadMainLocation());
                   SetText(_mText,"You've found a Sword");
                }
            }*/
        }
        
        IEnumerator LoadMainLocation()
        { 
            yield return new WaitForSeconds(6f);
            SceneManager.LoadScene("MainLocation");
        }

        public void Interact()
        {
            _chestAnim.SetTrigger("open");
            StartCoroutine(LoadMainLocation());
        }
    }
}
