/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-11-02 17:15:40
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.UI;

namespace EZhex1991.EZAnimation
{
    public class EZGraphicColorAnimation : EZAnimation<Graphic, EZColorSegment>
    {
        protected override void OnSegmentUpdate()
        {
            target.color = activeSegment.Evaluate(segmentProcess);
        }
    }
}