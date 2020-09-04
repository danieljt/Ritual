/*
Property of StupidGirlGames @Daniel James Tarplett.
Copying or redistribution is prohibited without written concent.
*/

using UnityEngine;

public class PlayerCrouchingLocomotionBehaviour : PlayerBaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerController.crouchDisableCollider.enabled = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        body.velocity = new Vector2(playerController.movement.x*3, body.velocity.y);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController.crouchDisableCollider.enabled = true;
    }

}
