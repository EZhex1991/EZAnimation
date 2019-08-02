/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-08-01 21:22:38
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    [System.Serializable]
    public class EZVector4Segment : EZAnimationSegment
    {
        [SerializeField]
        private Vector4 m_StartValue = Vector4.zero;
        public Vector4 startValue { get { return m_StartValue; } set { m_StartValue = value; } }

        [SerializeField]
        private Vector4 m_EndValue = Vector4.one;
        public Vector4 endValue { get { return m_EndValue; } set { m_EndValue = value; } }

        public Vector4 Evaluate(float time)
        {
            return Vector4.Lerp(startValue, endValue, time);
        }
    }
}
