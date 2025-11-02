using System;
using UnityEngine;
using UnityEngine.Events;

public class OnStartMediator : MonoBehaviour
{
    public UnityEvent onStart;

    private void Start()
    {
        onStart?.Invoke();
    }
}
