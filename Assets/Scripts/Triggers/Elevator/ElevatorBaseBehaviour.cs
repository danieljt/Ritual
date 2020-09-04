using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class ElevatorBaseBehaviour : StateMachineBehaviour
{
    // Components
    protected Elevator elevator;
    protected Rigidbody2D body;
    protected Animator animator;

    // Animator values
    protected int isMoving;
    protected int onTrigger;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!this.animator)
        {
            elevator = animator.gameObject.GetComponent<Elevator>();
            body = animator.gameObject.GetComponent<Rigidbody2D>();
            this.animator = animator;
            isMoving = Animator.StringToHash("isMoving");
            onTrigger = Animator.StringToHash("onTrigger");
        }
    }
}
