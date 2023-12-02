using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Alarm))]

public class Sensor : MonoBehaviour
{   
    private Alarm _alarm;              

    private void Start()
    {
        _alarm = GetComponent<Alarm> ();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Theif theif))
        {           
            _alarm.Enable();     
        }          
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Theif theif))
        {
            _alarm.Describe();
        }        
    }   
}
