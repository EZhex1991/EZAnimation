/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-10-31 15:25:39
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using System.Collections.Generic;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    public enum Status
    {
        Running = 1,
        Paused = 2,
        Stopped = 3
    }

    public delegate void OnAnimationEndAction();

    public abstract class EZAnimation : MonoBehaviour
    {
        [SerializeField]
        protected Status m_Status = Status.Stopped;
        public Status status { get { return m_Status; } protected set { m_Status = value; } }

        [SerializeField]
        protected float m_Time;
        public float time { get { return m_Time; } set { m_Time = value; } }

        public int segmentIndex { get; protected set; }
        public float segmentTime { get; protected set; }
        public float segmentProcess { get; protected set; }

        public abstract void StartSegment(int index);
        public abstract void Process(float time);

        public abstract void Play();
        public abstract void Pause();
        public abstract void Resume();
        public abstract void Stop();
    }

    public abstract class EZAnimation<TargetType, SegmentType> : EZAnimation
        where TargetType : Component
        where SegmentType : EZAnimationSegment, new()
    {
        [SerializeField]
        protected TargetType m_Target;
        public TargetType target { get { return m_Target; } set { m_Target = value; } }

        [SerializeField]
        protected bool m_Loop = true;
        public bool loop { get { return m_Loop; } set { m_Loop = value; } }

        [SerializeField]
        protected bool m_PlayOnAwake = true;
        public bool playOnAwake { get { return m_PlayOnAwake; } set { m_PlayOnAwake = value; } }

        [SerializeField]
        protected bool m_RestartOnEnable = false;
        public bool restartOnEnable { get { return m_RestartOnEnable; } set { m_RestartOnEnable = value; } }

        [SerializeField]
        protected AnimatorUpdateMode m_UpdateMode = AnimatorUpdateMode.Normal;
        public AnimatorUpdateMode updateMode { get { return m_UpdateMode; } set { m_UpdateMode = value; } }

        [SerializeField]
        protected List<SegmentType> m_Segments = new List<SegmentType>();
        public List<SegmentType> segments { get { return m_Segments; } set { m_Segments = value; } }

        public SegmentType activeSegment { get { return segments[segmentIndex]; } }

        public event OnAnimationEndAction onAnimationEndEvent;

        public override void StartSegment(int index = 0)
        {
            if (index >= segments.Count) return;
            time = 0;
            for (int i = 0; i < index; i++)
            {
                time += segments[i].duration;
            }
            status = Status.Running;
            segmentIndex = index;
            segmentTime = 0;
            OnSegmentStart();
            ProcessSegment(0);
        }
        protected virtual void ProcessSegment(float deltaTime)
        {
            time += deltaTime;
            segmentTime += deltaTime;
            segmentProcess = activeSegment.duration <= 0 ? 1 : activeSegment.curve.Evaluate(segmentTime / activeSegment.duration);
            OnSegmentUpdate();
            if (segmentTime > activeSegment.duration)
            {
                StopSegment();
            }
        }
        protected virtual void StopSegment()
        {
            OnSegmentStop();
            segmentIndex++;
            if (segmentIndex >= segments.Count)
            {
                if (onAnimationEndEvent != null) onAnimationEndEvent();
                if (loop)
                {
                    StartSegment(0);
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                StartSegment(segmentIndex);
            }
        }

        public override void Play()
        {
            StartSegment(0);
        }
        public override void Pause()
        {
            if (status == Status.Running)
                status = Status.Paused;
        }
        public override void Resume()
        {
            if (status == Status.Paused)
                status = Status.Running;
        }
        public override void Stop()
        {
            time = 0;
            status = Status.Stopped;
            segmentIndex = 0;
            segmentTime = 0;
            segmentProcess = 0;
        }

        public override void Process(float _time)
        {
            time = _time;
            if (segments.Count == 0) return;
            int _segmentIndex = 0;
            segmentProcess = Process(ref _segmentIndex, ref _time);
            segmentIndex = _segmentIndex;
            segmentTime = _time;
            ProcessSegment(0);
        }
        private float Process(ref int segmentIndex, ref float segmentTime)
        {
            if (segmentIndex >= segments.Count)
            {
                if (loop)
                {
                    segmentIndex = 0;
                    return Process(ref segmentIndex, ref segmentTime);
                }
                else
                {
                    segmentIndex = segments.Count - 1;
                    segmentTime = segments[segmentIndex].duration;
                    return 1;
                }
            }

            float duration = segments[segmentIndex].duration;
            if (segmentTime > duration)
            {
                segmentIndex++;
                segmentTime -= duration;
                return Process(ref segmentIndex, ref segmentTime);
            }
            else
            {
                return duration <= 0 ? 1 : (segmentTime / duration);
            }
        }

        protected virtual void OnSegmentStart()
        {
        }
        protected abstract void OnSegmentUpdate();
        protected virtual void OnSegmentStop()
        {

        }

        public bool IsRunning()
        {
            return activeSegment != null && status == Status.Running;
        }

        protected virtual void Awake()
        {
            if (playOnAwake) Play();
        }
        protected virtual void OnEnable()
        {
            if (restartOnEnable) Play();
        }
        protected void Update()
        {
            if (updateMode == AnimatorUpdateMode.AnimatePhysics) return;
            if (!IsRunning()) return;
            switch (updateMode)
            {
                case AnimatorUpdateMode.Normal:
                    ProcessSegment(Time.deltaTime);
                    break;
                case AnimatorUpdateMode.UnscaledTime:
                    ProcessSegment(Time.unscaledDeltaTime);
                    break;
            }
        }
        protected void FixedUpdate()
        {
            if (updateMode != AnimatorUpdateMode.AnimatePhysics) return;
            if (!IsRunning()) return;
            ProcessSegment(Time.fixedDeltaTime);
        }
        protected virtual void Reset()
        {
            m_Target = GetComponent<TargetType>();
            m_Segments = new List<SegmentType>()
            {
                new SegmentType(),
            };
        }
    }
}