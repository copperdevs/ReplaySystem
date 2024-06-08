using System;
using System.Collections.Generic;
using UnityEngine;

namespace CopperDevs.Replay
{
    public class ReplayRecorder : SingletonMonoBehaviour<ReplayRecorder>
    {
        [Header("Info")]
        [SerializeField] [ReadOnly] private float currentTime;

        [Header("Recordables settings")]
        [SerializeField] [Range(1, 60)] private int recordablesStateSaveFps = 50;
        [SerializeField] [ReadOnly] private float nextRecordablesStateSaveTime;
        private readonly Dictionary<Type, List<BaseRecordable>> registeredRecordables = new();

        [Header("Events")]
        [SerializeField] private List<Event> events = new();

        private void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime >= nextRecordablesStateSaveTime)
            {
                nextRecordablesStateSaveTime += 1f / recordablesStateSaveFps;
                SaveRecordables();
            }
        }
        
        private void SaveRecordables()
        {
        }

        public void RecordEvent(BaseEvent targetEvent)
        {
            events.Add(new Event { recordedTime = currentTime, recordedEvent = targetEvent });
        }

        internal void RegisterRecordable(BaseRecordable recordable)
        {
            var recordableType = recordable.GetType();

            // ReSharper disable once CanSimplifyDictionaryLookupWithTryGetValue
            if (registeredRecordables.ContainsKey(recordableType))
                registeredRecordables[recordableType].Add(recordable);
            else
                registeredRecordables.Add(recordableType, new List<BaseRecordable> { recordable });
        }

        internal void DeregisterRecordable(BaseRecordable recordable)
        {
            var recordableType = recordable.GetType();
            
            // ReSharper disable once CanSimplifyDictionaryLookupWithTryGetValue
            if (registeredRecordables.ContainsKey(recordableType))
                registeredRecordables[recordableType].Remove(recordable);
        }
    }
}