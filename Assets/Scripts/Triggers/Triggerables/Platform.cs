using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// A platform is a triggerable that can patrol between nodes. The platform is set up so it can wait
/// at nodes before patroling to the next node. The platform will always start in a state where it
/// patrols if it is active on start.
///</summary>
[RequireComponent(typeof(Animator))]
public class Platform : Triggerable
{
    [Tooltip("The id of this platform. Used for calculating what node transitions to follow")]
    public float id;

    [Tooltip("How long does this platform wait at a node before continuing")]
    public float waitingTime;

    [Tooltip("How fast does this platform move between nodes")]
    public float speed;

    private Animator animator;
    private Node targetNode;
    private NodeTransition[] nodeTransitions;
    
    ///<summary>
    /// The current target node.
    ///</summary>
    public Node TargetNode
    {
        get{return targetNode;}
    }
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.gameObject.GetComponent<Node>();
        if(node != null)
        {
            nodeTransitions = node.GetNodeTransitions();
        }
    }

    public override void OnNotify(int id)
    {
        animator.SetBool("isStopped", !animator.GetBool("isStopped"));
    }

    ///<summary>
    /// Get a new Target node
    ///</summary>
    public void SetTargetNode()
    {
        if(nodeTransitions != null)
        {
            for(int i=0; i<nodeTransitions.Length; i++)
            {
                if(nodeTransitions[i] != null && nodeTransitions[i].transitionParameter == id)
                {
                    targetNode = nodeTransitions[i].destinationNode;
                    return;
                }
            }
        }
    }
}
