/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-08-01 19:54:30
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace EZhex1991.EZAnimation
{
    [TrackClipType(typeof(EZAnimationClip))]
    [TrackBindingType(typeof(EZRendererFloatPropertyAnimation))]
    public class EZRendererFloatPropertyTrack : TrackAsset
    {
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            var controller = director.GetGenericBinding(this) as EZRendererFloatPropertyAnimation;
            if (controller == null || controller.target == null) return;
            driver.AddFromName<EZAnimation>(controller.gameObject, "m_Time");
            driver.AddFromComponent(controller.target.gameObject, controller.target);
#endif
            base.GatherProperties(director, driver);
        }
    }
}