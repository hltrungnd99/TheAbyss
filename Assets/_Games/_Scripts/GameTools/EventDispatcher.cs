using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventDispatcher
{
    public static Dictionary<EventName, List<Action<Component, object[]>>> _eventDictionary =
        new Dictionary<EventName, List<Action<Component, object[]>>>();

    public static void RegisterEventListener(this MonoBehaviour monoBehaviour, EventName eventName,
        Action<Component, object[]> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<Component, object[]>> lstEvent))
        {
            lstEvent.Add(listener);
            _eventDictionary[eventName] = lstEvent;
        }
        else
        {
            lstEvent = new List<Action<Component, object[]>>();
            lstEvent.Add(listener);
            _eventDictionary.Add(eventName, lstEvent);
        }
    }

    public static void RemoveEventListener(this MonoBehaviour monoBehaviour, EventName eventName,
        Action<Component, object[]> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<Component, object[]>> lstEvent))
        {
            if (lstEvent.Contains(listener))
            {
                lstEvent.Remove(listener);
            }

            _eventDictionary[eventName] = lstEvent;
        }
    }

    public static void PostEvent(this MonoBehaviour monoBehaviour, EventName eventName, object[] objs = null)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<Component, object[]>> lstEvent))
        {
            for (int i = 0; i < lstEvent.Count; i++)
            {
                lstEvent[i].Invoke(monoBehaviour, objs);
            }
        }
    }
}

public enum EventName
{
    ATTACK,
    TAKE_DAMAGE,
    START_ATK,
    END_ATK,
    END_ANIM,
}