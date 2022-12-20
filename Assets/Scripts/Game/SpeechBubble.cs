using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class SpeechBubble : MonoBehaviour
    {
        public static GameObject Create(Transform parent, Vector3 localPosition, string text)
        {
            GameObject speechBubbleTransform = Instantiate(_speechBubble,parent);
            speechBubbleTransform.transform.localPosition = localPosition;
            speechBubbleTransform.transform.rotation =  Quaternion.Euler(0,0,0);
            speechBubbleTransform.GetComponent<SpeechBubble>().Setup(text);
            return speechBubbleTransform;
        }

        public static GameObject _speechBubble;
        private TextMeshPro _textMeshPro;

        private void Awake()
        {
            _speechBubble = gameObject;
            _textMeshPro = GetComponent<TextMeshPro>();
        }
        
        private void Setup(string text)
        {
            _textMeshPro.SetText(text);
        }

    }
}