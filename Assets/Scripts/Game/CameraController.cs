using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private Vector3 _offset;

        void Start()
        {
            _offset = _target.position - transform.position;
        }

        void Update()
        {
            transform.position = _target.position - _offset;
            transform.LookAt(_target);
        }
    }
}
