using UnityEngine;

///<summary>
/// A lever is a simple trigger that is activated upon touch from the player. Following the
/// general interface from the Itrigger only an ontriggerenter script and a list of
/// triggerables is needed. Note, only interactors can activate the trigger.
///</summary>
public class Lever : Trigger
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactor interactor = other.GetComponent<Interactor>();
        if(interactor != null)
        {
            Notify();
        }
    }
}
