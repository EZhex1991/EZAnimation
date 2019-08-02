/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-11-02 17:02:01
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    public class EZRectTransformAnimation : EZAnimation<RectTransform, EZRectTransformSegment>
    {
        protected override void OnSegmentUpdate()
        {
            target.anchoredPosition = Vector2.Lerp(activeSegment.startRect.anchoredPosition, activeSegment.endRect.anchoredPosition, segmentProcess);
            target.anchorMin = Vector2.Lerp(activeSegment.startRect.anchorMin, activeSegment.endRect.anchorMin, segmentProcess);
            target.anchorMax = Vector2.Lerp(activeSegment.startRect.anchorMax, activeSegment.endRect.anchorMax, segmentProcess);
            target.pivot = Vector2.Lerp(activeSegment.startRect.pivot, activeSegment.endRect.pivot, segmentProcess);
            target.sizeDelta = Vector2.Lerp(activeSegment.startRect.sizeDelta, activeSegment.endRect.sizeDelta, segmentProcess);
            target.rotation = Quaternion.Lerp(activeSegment.startRect.rotation, activeSegment.endRect.rotation, segmentProcess);
            target.localScale = Vector3.Lerp(activeSegment.startRect.localScale, activeSegment.endRect.localScale, segmentProcess);
        }
    }
}