using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data", order = 51)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private bool _doubleJump;
        [SerializeField] private bool _isArmed;

        public bool DoubleJump
        {
            get => _doubleJump;
            set => _doubleJump = value;
        }
        
        public bool IsArmed
        {
            get => _isArmed;
            set => _isArmed = value;
        }
    }
}
