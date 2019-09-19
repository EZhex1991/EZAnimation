/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-03-29 18:05:26
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Timeline;

namespace EZhex1991.EZAnimation
{
    [TrackClipType(typeof(EZAnimationClip))]
    [TrackBindingType(typeof(EZRectTransformAnimation))]
    public class EZRectTransformTrack : EZAnimationTrack
    {
    }
}