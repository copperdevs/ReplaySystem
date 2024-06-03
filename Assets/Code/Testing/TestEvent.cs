using UnityEngine;

// for testing purposes only
[CreateAssetMenu(fileName = "New Test Event", menuName = "Test Event", order = 1)]
public class TestEvent : BaseEvent
{
    public override void ReplayEvent()
    {
        Debug.Log("Test Event Played", this);
    }
}