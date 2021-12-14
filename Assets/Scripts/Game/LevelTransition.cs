using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] private GameObject _text;
        private bool _canGo;
        public enum Destination { Forest, Mountains };
        [Header("Destination")]
        public Destination LocationToGo;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                _text.SetActive(true);
                _canGo = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                _text.SetActive(false);
                _canGo = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown("e")&& _canGo && LocationToGo == Destination.Forest)
            {
                SceneManager.LoadScene("ForestLocation");
            }
            
            if (Input.GetKeyDown("e")&& _canGo && LocationToGo == Destination.Mountains)
            {
                SceneManager.LoadScene("MountainsLocation");
            }
        }
    }
}