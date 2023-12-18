using UnityEngine;

public class Resource : MonoBehaviour 
{
    public bool IsTarget { get; private set; }

    public void BecomeTarget()
    {
        IsTarget = true;
    }
}

