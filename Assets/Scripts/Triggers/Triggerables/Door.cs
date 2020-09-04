using System.Collections;
using UnityEngine;

///<summary>
/// A door is a simple static entity that is triggered by a trigger. A door can be open, shut, opening
/// or closing. An animator is used for this statemachine together with a box collider. 
///<summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class Door : Triggerable
{
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;

    ///<summary>
    /// The box collider associated with this gameobject
    ///</summary>
    public BoxCollider2D BoxCollider
    {
        get{return boxCollider;}
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public override void OnNotify(int id)
    {
        animator.SetTrigger("onTrigger");
    }
}
