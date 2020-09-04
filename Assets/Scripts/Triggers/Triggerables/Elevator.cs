using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// An elevator defines a platform that can move between nodes. An elevator is triggered by switches,
/// levers or buttons to make it move between the choosen nodes.
///</summary>
public class Elevator : Triggerable
{
    [Tooltip("Speed of the elevator")]
    public float speed;
    private Animator animator;
    private NodeTransition[] transitions;
    private Node targetNode;

    public Node TargetNode
    {
        get{return targetNode;}
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnNotify(int id)
    {
        for(int i=0; i<transitions.Length; i++)
        {
            if(transitions[i] != null && transitions[i].transitionParameter == id)
            {
                targetNode = transitions[i].destinationNode;
            }
        }

        animator.SetTrigger("onTrigger");
    }

    ///<summary>
    /// The primary responsibility of the callback is to check if a collision is with a
    /// gameobject with a node component and add the nodes transitions to the this component.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.gameObject.GetComponent<Node>();
        if(node != null)
        {
            transitions = node.GetNodeTransitions();
        }
    }
}
