using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// The climbable controller is responsible for detecting climbable objects for the player to
/// latch on to. This class is only responsible for detecting intersection with colliders and
/// providing callbacks via the public variable isTouching. This class derives from the standart touchboxController
/// class, but have this in mind. The collider needs to be large enough to intersect the edges of the collider
/// in some way. If not, it wont detect anything. This class might need a raycast function or two to be able
/// to properly detect the inside of a climbable. When using a tilemap, consider avoiding using a composite 
/// collider as this creates more complicated colliders.
///</summary>
public class ClimbableController : MonoBehaviour
{
    [Tooltip("What is defined as climbable")]
    public LayerMask whatIsTouchable;

    [Tooltip("Length of the Raycasts. Raycasts are sent from the center of the gamobject up and down")]
    public float rayCastLengths;

    [HideInInspector] public bool isTouching;

    protected Collider2D hitCollider;
    private RaycastHit2D upwardsRay;
    private RaycastHit2D downwardsRay; 

    public Collider2D Collider
    {
        get{return hitCollider;}
    }

    public Vector2 ContactPoint
    {
        get{return upwardsRay.point;}
    }

    private void FixedUpdate()
    {
        upwardsRay = Physics2D.Raycast(transform.position, Vector2.up, rayCastLengths, whatIsTouchable);
        if(upwardsRay.collider != null)
        {
            hitCollider = upwardsRay.collider;
            isTouching = true;
        }

        else
        {
            isTouching = false;
        }
    }
}
