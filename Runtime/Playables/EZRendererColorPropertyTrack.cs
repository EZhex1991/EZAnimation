/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-08-01 19:54:30
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Timeline;

namespace EZhex1991.EZAnimation
{
    [TrackClipType(typeof(EZAnimationClip))]
    [TrackBindingType(typeof(EZRendererColorPropertyAnimation))]
    public class EZRendererColorPropertyTrack : EZAnimationTrack
    {
    }
}