using UnityEngine;

///<summary>
/// A node is a position in space where a moving object can travel to and from. A node i part
/// of a system for platforms, doors and other moving objects. A node consists of a set of 
/// node transitions telling if the node can send the platforms that way.
///</summary>
public class Node : MonoBehaviour
{
    private NodeTransition[] nodeTransitions;

    private void Awake()
    {
        nodeTransitions = GetComponents<NodeTransition>();
    }

    public NodeTransition[] GetNodeTransitions()
    {
        return nodeTransitions;
    }
}
