using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
      private Camera _mainCamera;
      [SerializeField] private GameObject _uiPanel;
      [SerializeField] private TextMeshProUGUI _promptText;
      public bool IsDisplayed = false;

      private void Start()
      {
            _mainCamera = Camera.main;
            _uiPanel.SetActive(false);
      }

      private void LateUpdate()
      {
            var rotation = _mainCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, 
                  rotation * Vector3.up);
      }

      
      public void SetUpText(string promptText)
      {
            _promptText.text = promptText;
            _uiPanel.SetActive(true);
            IsDisplayed = true;
      }

      public void Close()
      {
            IsDisplayed = false;
            _uiPanel.SetActive(false);
      }
}