using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _background;
   
    private void Update()
    {
        transform.position = new Vector3(_player.position.x, _background.position.y, _background.position.z);
    }
}
