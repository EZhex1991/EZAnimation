/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-03-29 20:37:32
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine.Playables;

namespace EZhex1991.EZAnimation
{
    public class EZAnimationPlayableBehaviour : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            EZAnimation controller = playerData as EZAnimation;
            if (controller == null) return;
            controller.Process((float)playable.GetTime());
        }
    }
}
