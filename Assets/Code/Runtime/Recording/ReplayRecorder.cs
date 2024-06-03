using System;
using System.Collections.Generic;
using UnityEngine;

public class ReplayRecorder : SingletonMonoBehaviour<ReplayRecorder>
{
    [SerializeField] [ReadOnly] private float currentTime;
    [SerializeField] private List<Event> events = new();


    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    [ContextMenu("New Event")]
    private void NewEvent()
    {
        events.Add(new Event { recordedTime = currentTime });
    }

    public void RecordEvent(BaseEvent targetEvent)
    {
        events.Add(new Event {recordedTime = currentTime, recordedEvent = targetEvent});
    }

    [Serializable]
    public class Event
    {
        public float recordedTime;
        public BaseEvent recordedEvent;
    }
}