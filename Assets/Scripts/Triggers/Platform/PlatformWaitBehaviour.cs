using UnityEngine;

///<summary>
/// The platform has reached it's destination, and will wait for the timer to reach
/// zero before continuing to the next target.
///<summary>
public class PlatformWaitBehaviour : PlatformBaseBehaviour
{
    private float timer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timer = platform.waitingTime;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if(timer <= 0)
        {
            platform.SetTargetNode();
            animator.SetBool(isMoving, true);
        }

        timer -= Time.fixedDeltaTime;
    }
}
