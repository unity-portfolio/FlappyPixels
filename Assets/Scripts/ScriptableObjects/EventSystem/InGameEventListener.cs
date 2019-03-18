using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with")]
    public InGameEvent _event;

    [Tooltip("Response to invoke when event is being raised")]
    public UnityEvent response;

    private void OnEnable()
    {
        _event.RegisterListener(this);
    }

    private void OnDisable()
    {
        _event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
