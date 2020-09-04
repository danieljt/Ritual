using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// The platform is stopped by a trigger. The trigger must be set again so that
/// the platform can continue it's routine.
///</summary>
public class PlatformStopBehaviour : PlatformBaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
}
