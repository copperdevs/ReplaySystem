using UnityEngine;

namespace CopperDevs.Replay
{
    public class BaseRecordable : MonoBehaviour
    {
        private void OnEnable()
        {
            ReplayRecorder.Instance.RegisterRecordable(this);
        }

        private void OnDisable()
        {
            ReplayRecorder.Instance.DeregisterRecordable(this);
        }
    }
}