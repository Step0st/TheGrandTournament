using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class LevelTransition : MonoBehaviour, IInteractable
    {
        public enum Destination { Forest, Mountains };
        [Header("Destination")]
        public Destination _locationToGo;
        
        [SerializeField] private string _prompt;
        public string InteractionPrompt => _prompt;

        public void Interact()
        {
            switch (_locationToGo)
            {
                case Destination.Forest:
                    SceneManager.LoadScene("ForestLocation");
                    break;
                case Destination.Mountains:
                    SceneManager.LoadScene("MountainsLocation");
                    break;
            }
        }

        public void ResetInteraction()
        {
        }
    }
}