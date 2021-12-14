using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movespeed;
        [SerializeField] private float _jumpforce;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private LayerMask Ground;
        [SerializeField] private GameObject _gameSounds;
        [Header("Equipment")]
        [SerializeField] private GameObject _sword;
        private bool _canDoubleJump = false;
        private bool _secondJump;
        private Rigidbody _rigidbody;
        private bool _isGrounded = true;
        private bool _isMoving;
        private SoundsManager _sounds;
        private Vector3 _bottomOfPlayer;
        private Vector3 _movingVector;
        private Animator _animator;
        


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _sounds = _gameSounds.GetComponent<SoundsManager>();
            if (_playerData.DoubleJump)
            {
                _canDoubleJump = true;
            }
            
            if (_playerData.IsArmed)
            {
                _sword.SetActive(true);
            }
            
        }

        void Update()
        {

            _bottomOfPlayer = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _isGrounded = Physics.CheckSphere(_bottomOfPlayer, 0.3f, Ground, QueryTriggerInteraction.Ignore);

            _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * _movespeed, _rigidbody.velocity.y, 0);
            _movingVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            

            if (_movingVector.magnitude > 0.1f)
            {
                Quaternion toRotation =
                    Quaternion.LookRotation(new Vector3(_rigidbody.velocity.normalized.x, 0, 0), Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1440 * Time.deltaTime);
                _animator.SetBool("IsMoving", true);
                
                if (_sounds.source.isPlaying == false)
                {
                    _sounds.StepSound();
                }
            }
            else
            {
                _animator.SetBool("IsMoving", false);
                if (_sounds.source.isPlaying == true)
                {
                    _sounds.source.Stop();
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                PlayerJump();
            }
        }
        
        private void PlayerJump()
        {
            if (_isGrounded)
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpforce, _rigidbody.velocity.z);
                _secondJump = true;
                _gameSounds.GetComponent<SoundsManager>().JumpSound();

            }
            else
            {
                if (_canDoubleJump && _secondJump)
                {
                    _secondJump = false;
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpforce, _rigidbody.velocity.z);
                    _gameSounds.GetComponent<SoundsManager>().JumpSound();
                }
            }
        }
    }
}
