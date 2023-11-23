using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(AudioSource))]

public class Sensor : MonoBehaviour
{   
    [SerializeField] private float _detectionDistance;
    [SerializeField] private Color _detectionColor;

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private Color _defaultColor;
    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _defaultColor = _spriteRenderer.color;
        _audioSource.volume = _minVolume;       
    }

    private void Update()
    {
        RaycastHit2D detection = Physics2D.Raycast(transform.position, -transform.right, _detectionDistance);       

        if (detection)
        {
            _spriteRenderer.color = _detectionColor;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
        else
        {
            _spriteRenderer.color = _defaultColor;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeVolume(_minVolume));
        }         
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        float volume = _audioSource.volume;
        float step = 0.001f;

        while (volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(volume, targetVolume, step);
            
            yield return null;
        }
    }
}
