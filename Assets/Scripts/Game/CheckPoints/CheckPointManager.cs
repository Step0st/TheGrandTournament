using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] private List<CheckPoint> _checkPoints;
    private CheckPoint _currentCheckPoint;
    public CheckPoint CurrentCheckPoint => _currentCheckPoint;

    private void Awake()
    {
        foreach (var checkPoint in _checkPoints)
        {
            checkPoint.OnCheckPointReached += () => { ChangeCheckPoint(checkPoint); };
        }
    }

    private void ChangeCheckPoint(CheckPoint checkPoint)
    {
        _currentCheckPoint = checkPoint;
    }
}

