using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosedBehaviour : StateMachineBehaviour
{
    private Door door;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        door = animator.gameObject.GetComponent<Door>();
        door.BoxCollider.enabled = true;
    }
}
