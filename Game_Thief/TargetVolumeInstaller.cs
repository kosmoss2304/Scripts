using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class TargetVolumeInstaller : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private float _minVolume = 0;   
    private float _currentVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }
   
    public void TakeTargetVolume(float targetVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        float step = 0.001f;

        _currentVolume = _audioSource.volume;

        while (_currentVolume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_currentVolume, targetVolume, step);

            yield return null;
        }
    }
}
