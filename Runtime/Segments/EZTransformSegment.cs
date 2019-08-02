/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-12-11 17:47:10
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using System;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    [Serializable]
    public class EZTransformSegment : EZAnimationSegment
    {
        [SerializeField]
        private EZTransformPathPoint m_StartPoint;
        public EZTransformPathPoint startPoint { get { return m_StartPoint; } set { m_StartPoint = value; } }
        [SerializeField]
        private EZTransformPathPoint m_EndPoint;
        public EZTransformPathPoint endPoint { get { return m_EndPoint; } set { m_EndPoint = value; } }
    }
}