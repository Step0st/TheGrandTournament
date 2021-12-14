using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class TriggerForSpeech : MonoBehaviour
    {
        [SerializeField] private GameObject _text;
        [SerializeField] private string _speechText;
        private bool _canSpeak;
        private Transform _player;
        private GameObject _speech;


        private void Start()
        {
            _player = FindObjectOfType<PlayerController>().transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                _text.SetActive(true);
                _canSpeak = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                _text.SetActive(false);
                _canSpeak = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown("e") && _canSpeak)
            {
                //StartCoroutine(TextForTime());
                _speech = SpeechBubble.Create(_player,new Vector3(0,1.2f,0),_speechText);
                Destroy(_speech,7f);
            }

            if (_speech != null)
            {
                _speech.transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        

        //IEnumerator TextForTime()
        //{
            //_speech = SpeechBubble.Create(_player,new Vector3(0,1.2f,0),_speechText);
            //Destroy(_speech,2f);
            //yield return new WaitForSeconds(3f);
            //_speech = null;
        //}
    }
}