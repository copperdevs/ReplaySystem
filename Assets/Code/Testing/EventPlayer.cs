using UnityEngine;

namespace CopperDevs.Replay
{
    public class EventPlayer : MonoBehaviour
    {
        [SerializeField] private TestEvent targetEvent;

        [ContextMenu("Run Event")]
        public void RunEvent()
        {
            targetEvent.RecordEvent();
        }
    }
}