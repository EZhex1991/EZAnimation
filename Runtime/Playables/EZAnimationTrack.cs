/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-09-19 16:17:11
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace EZhex1991.EZAnimation
{
    public abstract class EZAnimationTrack : TrackAsset
    {
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
            var controller = director.GetGenericBinding(this) as EZAnimation;
            if (controller == null || controller.targetComponent == null) return;
            driver.AddFromComponent(controller.targetComponent.gameObject, controller.targetComponent);
            base.GatherProperties(director, driver);
        }
    }
}
