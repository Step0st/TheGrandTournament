using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MovingPlatforms : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _movingRange = 4f;

        [Tooltip("LeftRight movement if checked, UpDown otherwise")] [SerializeField]
        private bool _leftRightMovement;

        private bool _moveRight = true;
        private bool _moveUp = true;
        private float _leftEdge;
        private float _rightEdge;
        private float _upEdge;
        private float _downEdge;

        private void Start()
        {
            _rightEdge = transform.localPosition.x + _movingRange / 2;
            _leftEdge = transform.localPosition.x - _movingRange / 2;
            _upEdge = transform.localPosition.y + _movingRange / 2;
            _downEdge = transform.localPosition.y - _movingRange / 2;
        }

        void Update()
        {
            if (_leftRightMovement)
            {
                LeftRightMovement();
            }
            else
            {
                UpDownMovement();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "Player")
            {
                other.collider.transform.SetParent(transform);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.name == "Player")
            {
                other.collider.transform.SetParent(null);
            }
        }

        private void LeftRightMovement()
        {
            if (transform.localPosition.x > _rightEdge)
            {
                _moveRight = false;
            }

            if (transform.localPosition.x < _leftEdge)
            {
                _moveRight = true;
            }

            if (_moveRight)
            {
                transform.position = new Vector3(transform.position.x + _moveSpeed * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - _moveSpeed * Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
            }
        }

        private void UpDownMovement()
        {
            if (transform.localPosition.y > _upEdge)
            {
                _moveUp = false;
            }

            if (transform.localPosition.y < _downEdge)
            {
                _moveUp = true;
            }

            if (_moveUp)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + _moveSpeed * Time.deltaTime,
                    transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y - _moveSpeed * Time.deltaTime,
                    transform.position.z);
            }
        }
    }
}
