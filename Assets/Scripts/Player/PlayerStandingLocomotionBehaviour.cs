/*
Property of StupidGirlGames @Daniel James Tarplett.
Copying or redistribution is prohibited without written concent.
*/

using UnityEngine;

///<summary>
/// Behaviour governing all ground movement locomotion, including idle, walking, running, crouching and sneaking.
/// This class is more monolithic, but spares us workload in the animator. This also saves us from transitions
/// and the workload from that.
///<summary>
public class PlayerStandingLocomotionBehaviour : PlayerBaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        body.velocity = new Vector2(playerController.movement.x*5,body.velocity.y);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
