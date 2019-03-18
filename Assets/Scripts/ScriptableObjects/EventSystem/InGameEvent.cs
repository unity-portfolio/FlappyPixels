using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game/Events", order =0)]
public class InGameEvent : ScriptableObject
{
    private List<InGameEventListener> eventListeners = new List<InGameEventListener>();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(InGameEventListener listener)
    {
        if(!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(InGameEventListener listener)
    {
        if(eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}
