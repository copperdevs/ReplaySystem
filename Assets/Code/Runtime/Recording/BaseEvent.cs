using UnityEngine;

public abstract class BaseEvent : ScriptableObject
{
    public void RecordEvent()
    {
        ReplayRecorder.Instance.RecordEvent(this);
    }

    public abstract void ReplayEvent();
}