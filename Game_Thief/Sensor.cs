using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Sensor : MonoBehaviour
{   
    [SerializeField] private SoundControl _soundControl;
    [SerializeField] private float _detectionDistance;
    [SerializeField] private Color _detectionColor;

    private SpriteRenderer _spriteRenderer;    
    private Color _defaultColor;
    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();      
        _defaultColor = _spriteRenderer.color;           
    }

    private void Update()
    {
        RaycastHit2D detection = Physics2D.Raycast(transform.position, - transform.right, _detectionDistance);       

        if (detection)
        {
            _spriteRenderer.color = _detectionColor;
            _soundControl.TakeTargetVolume(_maxVolume);
        }
        else
        {
            _spriteRenderer.color = _defaultColor;
            _soundControl.TakeTargetVolume(_minVolume);
        }         
    }
}
