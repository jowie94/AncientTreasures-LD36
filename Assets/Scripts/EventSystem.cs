using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace MandarineStudio.AncientTreaseures
{
    public class EventSystem
    {
        private Dictionary<string, UnityEvent<List<object>>> m_eventsParams = new Dictionary<string, UnityEvent<List<object>>>();
        private Dictionary<string, UnityEvent> m_events = new Dictionary<string, UnityEvent>();

        public void Subscribe(string eventName, UnityAction action)
        {
            UnityEvent unityEvent;
            if (!m_events.TryGetValue(eventName, out unityEvent))
            {
                unityEvent = new UnityEvent();
                m_events[eventName] = unityEvent;
            }
            unityEvent.AddListener(action);
        }

        public void Unsubscribe(string eventName, UnityAction action)
        {
            UnityEvent unityEvent;
            if (m_events.TryGetValue(eventName, out unityEvent))
                unityEvent.RemoveListener(action);
        }

        public void Trigger(string eventName)
        {
            UnityEvent unityEvent;
            if (m_events.TryGetValue(eventName, out unityEvent))
                m_events[eventName].Invoke();
            else
                Debug.LogError("Event with name " + eventName + " does not exists!");
        }

        public void Reset()
        {
            m_events.Clear();
            m_eventsParams.Clear();
        }
    }
}