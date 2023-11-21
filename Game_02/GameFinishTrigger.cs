using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameFinishTrigger : MonoBehaviour
{
    private Coin[] _coins;

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in _coins)       
            coin.Reached += OnEndPointReached;       
    }

    
    private void OnDisable()
    {
        foreach (var coin in _coins)       
            coin.Reached -= OnEndPointReached;       
    }

    private void OnEndPointReached()
    {
        foreach(var coin in _coins)        
            if (coin.IsReached == false)
                return;      
    }
}
