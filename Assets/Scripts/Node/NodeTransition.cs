using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Defines a transition between two nodes. A transition requires an int that is given through
/// the sender to this transition.
///</summary>
public class NodeTransition : MonoBehaviour
{
    public Node destinationNode;
    public int transitionParameter;

    ///<summary>
    /// Get the transition node
    ///</summary>
    public Node GetNode()
    {
        return destinationNode;
    }
}
