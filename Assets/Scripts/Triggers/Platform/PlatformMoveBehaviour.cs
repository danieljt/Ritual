using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// The platform is moving towards it's target.
///</summary>
public class PlatformMoveBehaviour : PlatformBaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(Vector2.SqrMagnitude(animator.gameObject.transform.position - platform.TargetNode.transform.position) > 0.01*0.01f)
        {
            body.MovePosition(Vector2.MoveTowards(animator.gameObject.transform.position, platform.TargetNode.transform.position, Time.fixedDeltaTime*platform.speed));
        }
        else
        {
            body.MovePosition(platform.TargetNode.transform.position);
            animator.SetBool(isMoving, false);
        }
    }
}
