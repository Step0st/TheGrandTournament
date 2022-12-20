using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditssFlight : MonoBehaviour
{
    private Vector3 _initPos;
    private void Start()
    {
        _initPos = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = _initPos;
    }

    void Update()
    {
        transform.position += new Vector3(0, 60 * Time.deltaTime, 0);
    }
}
