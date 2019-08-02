/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-03-29 18:05:26
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace EZhex1991.EZAnimation
{
    [TrackClipType(typeof(EZAnimationClip))]
    [TrackBindingType(typeof(EZGraphicColorAnimation))]
    public class EZGraphicColorTrack : TrackAsset
    {
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            var controller = director.GetGenericBinding(this) as EZGraphicColorAnimation;
            if (controller == null || controller.target == null) return;
            driver.AddFromName<EZGraphicColorAnimation>(controller.gameObject, "m_Time");
            driver.AddFromName<Graphic>(controller.target.gameObject, "m_Color");
#endif
            base.GatherProperties(director, driver);
        }
    }
}