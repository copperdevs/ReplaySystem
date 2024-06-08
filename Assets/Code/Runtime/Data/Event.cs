using System;

namespace CopperDevs.Replay
{
    [Serializable]
    internal class Event
    {
        public float recordedTime;
        public BaseEvent recordedEvent;
    }
}