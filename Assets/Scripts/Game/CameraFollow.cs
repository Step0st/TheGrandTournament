using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _yOffset = 3;
        [SerializeField] private float _zOffset = -15;
        [SerializeField] private float _smoothTime = 0.15f;
        private Vector3 _offset;
        private Vector3 _velocity = Vector3.zero;

        void Start()
        {
            _offset = new Vector3(0f, _yOffset, _zOffset);
        }

        void Update()
        {
            Vector3 targetPosition = _target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref _velocity,_smoothTime);
        }
    }
}
