using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _numOfHearts;

    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _emptyHeart;


    private void Start()
    {
        SetHealth(_health);
    }

    public void SetHealth(int health)
    {
        var currentHealth = health;
        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i].sprite = i < currentHealth ? _fullHeart : _emptyHeart;
            //_hearts[i].enabled = i < _numOfHearts ? true : false;
        }
    }
    
    
}
