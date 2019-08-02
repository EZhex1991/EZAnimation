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
    public class EZColorSegment : EZAnimationSegment
    {
        [SerializeField]
        private Gradient m_Gradient = EZAnimationUtility.GradientFadeOut();
        public Gradient gradient { get { return m_Gradient; } set { m_Gradient = value; } }

        public Color Evaluate(float time)
        {
            return gradient.Evaluate(time);
        }
    }
}