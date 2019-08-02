/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-12-11 17:45:04
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using System;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    [Serializable]
    public class EZFloatSegment : EZAnimationSegment
    {
        [SerializeField]
        private float m_StartValue = 0;
        public float startValue { get { return m_StartValue; } set { m_StartValue = value; } }

        [SerializeField]
        private float m_EndValue = 1;
        public float endValue { get { return m_EndValue; } set { m_EndValue = value; } }

        public float Evaluate(float time)
        {
            return Mathf.Lerp(startValue, endValue, time);
        }
    }
}