/* Author:          ezhex1991@outlook.com
 * CreateTime:      2018-01-24 14:53:33
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    public static class EZAnimationUtility
    {
        public static Gradient GradientFadeOut()
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(Color.white, 0),
                new GradientColorKey(Color.black, 1),
            };
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
            {
                new GradientAlphaKey(1, 0),
                new GradientAlphaKey(0, 1),
            };

            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            return gradient;
        }
        public static Gradient GradientFadeIn()
        {
            GradientColorKey[] colorKeys = new GradientColorKey[]
            {
                new GradientColorKey(Color.black, 0),
                new GradientColorKey(Color.white, 1),
            };
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
            {
                new GradientAlphaKey(0, 0),
                new GradientAlphaKey(1, 1),
            };

            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            return gradient;
        }
    }
}