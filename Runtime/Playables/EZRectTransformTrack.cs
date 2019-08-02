/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-03-29 18:05:26
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace EZhex1991.EZAnimation
{
    [TrackClipType(typeof(EZAnimationClip))]
    [TrackBindingType(typeof(EZRectTransformAnimation))]
    public class EZRectTransformTrack : TrackAsset
    {
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            var controller = director.GetGenericBinding(this) as EZRectTransformAnimation;
            if (controller == null || controller.target == null) return;
            driver.AddFromName<EZRectTransformAnimation>(controller.gameObject, "m_Time");
            driver.AddFromComponent(controller.target.gameObject, controller.target);
#endif
            base.GatherProperties(director, driver);
        }
    }
}