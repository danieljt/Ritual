using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingLocomotionBehaviour : PlayerBaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        body.velocity = new Vector2(playerController.movement.x*5, 3);
    }
}
