using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Parent a collider when it touches a collider with this component.
/// Usefull for moving platforms where objects need to stick to the platform.
///</summary>
public class ParentOnTouch : MonoBehaviour
{
    public LayerMask whatCanBeParented;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if((whatCanBeParented.value & 1 << other.gameObject.layer) > 0)
        {
            other.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if((whatCanBeParented.value & 1 << other.gameObject.layer) > 0)
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
