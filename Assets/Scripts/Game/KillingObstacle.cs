using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class KillingObstacle : MonoBehaviour
    {
        private LevelManager _levelManager;

        void Start()
        {
            _levelManager = FindObjectOfType<LevelManager>();
        }


        public void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                _levelManager.RespawnPlayer();
            }
        }
    }
}

