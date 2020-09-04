using UnityEngine;

public class ElevatorLocomotionBehaviour : ElevatorBaseBehaviour
{
    private Vector2 currentPosition;
    private Vector2 targetPosition;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool(isMoving, true);
        targetPosition = elevator.TargetNode.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPosition = animator.gameObject.transform.position;

        if(Vector2.SqrMagnitude(targetPosition - currentPosition) > 0.001f*0.001f)
        {
            body.MovePosition(Vector2.MoveTowards(currentPosition, targetPosition, elevator.speed*Time.fixedDeltaTime));

        }
        else
        {
            body.MovePosition(targetPosition);
            animator.SetBool(isMoving, false);
        }
    }
}
