using UnityEngine;

// for testing purposes only
public class EventPlayer : MonoBehaviour
{
    [SerializeField] private TestEvent targetEvent;

    [ContextMenu("Run Event")]
    public void RunEvent()
    {
        targetEvent.RecordEvent();
    }
}