using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelManager : MonoBehaviour
    {
        public GameObject currentCheckpoint;

        private PlayerController _player;

        void Start()
        {
            _player = FindObjectOfType<PlayerController>();

        }
        
        public void RespawnPlayer()
        {
            _player.transform.position = currentCheckpoint.transform.position;
        }
    }
}
