using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Base behaviour for a platform. Performs all getcomponents and 
/// animator stringToHash functions so you don't have to
///</summary>
public class PlatformBaseBehaviour : StateMachineBehaviour
{
    protected Platform platform;
    protected Rigidbody2D body;
    protected Animator animator;

    protected int isMoving;
    protected int isStopped; 

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!this.animator)
        {
            this.animator = animator;
            platform = animator.gameObject.GetComponent<Platform>();
            body = animator.gameObject.GetComponent<Rigidbody2D>();
            isMoving = Animator.StringToHash("isMoving");
            isStopped = Animator.StringToHash("isStopped");
        }
    }
}
