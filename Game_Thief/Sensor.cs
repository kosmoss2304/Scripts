using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Alarm))]

public class Sensor : MonoBehaviour
{   
    private Alarm _alarm;          
    private bool _isDetectedThief;

    private void Start()
    {
        _alarm = GetComponent<Alarm> ();
    }

    private void Update()
    {                
        _alarm.TakeTargetVolume(Convert.ToInt32(_isDetectedThief));       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Theif theif))       
            _isDetectedThief = true;        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        _isDetectedThief = false;       
    }   
}
