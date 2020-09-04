﻿/*
Property of StupidGirlGames @Daniel James Tarplett.
Copying or redistribution is prohibited without written concent.
*/

using UnityEngine;

///<summary>
/// The touchboxcontroller is responsible for checking if a gameobject
/// is in contact with the gameobjects. This is done by applying a overlapsbox
/// at a position relative to the gameobjects transform. A layermask is used to filter
/// out what this gameobject should touch. The groundcontroller communicates the results
/// to the animator state machine, so make sure to set the statemachine 
/// properly.
///</summary>
public class TouchBoxController : MonoBehaviour
{
    [Tooltip("The layers that define the objects that this object should touch.")]
    public LayerMask whatIsTouchable;

    [Tooltip("The centerposition of the cast with respect to the gamobjects position.")]
    public Vector2 castPosition;

    [Tooltip("The size of the box cast")]
    public Vector2 castSize;

    [Tooltip("How many colliders the cast should return, in case there are multiple hits. If there are more hits, then some will be omitted")]
    public int castColliders;

    [HideInInspector] public bool isTouching;

    protected Collider2D[] colliders;

    public Collider2D[] Colliders
    {
        get{return colliders;}
    }

    private void Awake()
    {
        colliders = new Collider2D[castColliders];
        isTouching = true;
    }

    private void FixedUpdate()
    {
        // Cast the position of the gameobjects transform to a vector2 before running the boxcast. Then run
        // the overlaps box function to get a collider amount. Use Non allocation to prevent 
        // unessesary garbage collection.
        Vector2 position = transform.position;
        int collidersHit = Physics2D.OverlapBoxNonAlloc(position + castPosition, castSize, 0, colliders, whatIsTouchable);

        // If the cast gives an aount of colliders then the object is in contact with the ground and the animator
        // value should be set to true. If no colliders are hit then the animator parameter is set to false.
        if(collidersHit > 0)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 position = transform.position;
        Gizmos.DrawWireCube(position + castPosition, castSize);
    }
}
