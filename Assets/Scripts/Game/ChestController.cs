using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Game
{
    public class ChestController : MonoBehaviour
    {

        [SerializeField] private Animator _chestAnim;
        [SerializeField] private GameObject _mText;
        [SerializeField] private PlayerData _playerData;
        private bool _chestFlag = false;

        public enum Reward
        {
            DoubleJumpBoots,
            Sword
        };

        [Header("Reward")] public Reward rewardType;

        private void Update()
        {
            if (Input.GetKeyDown("e") && _chestFlag)
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
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                _chestAnim.SetTrigger("open");
                _chestFlag = true;
                _mText.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                _chestAnim.SetTrigger("close");
                _chestFlag = false;
                _mText.SetActive(false);
            }
        }

        private void SetText(GameObject textObject, string text)
        {
            textObject.GetComponent<TextMeshPro>().text = text;
        }
        
        IEnumerator LoadMainLocation()
        { 
            yield return new WaitForSeconds(6f);
            SceneManager.LoadScene("MainLocation");
        }
    }
}
