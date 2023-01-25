using UnityEngine;
[CreateAssetMenu(menuName = "Defs/PlayerDef", fileName = "PlayerDef")]
public class PlayerDef : ScriptableObject
{
        [SerializeField] private int _maxHealth;

        public int MaxHealth => _maxHealth;
}