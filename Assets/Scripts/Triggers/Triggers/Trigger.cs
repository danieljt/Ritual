using System.Collections.Generic;
using UnityEngine;

///<summary>
/// A trigger represents something that can be interacted with. Like a button, lever, 
/// floor panel etc. A trigger holds a set of triggerable objects that are triggered when
/// this trigger is interacted with. A trigger contains a set of integer states that can be
/// read from the triggerable objects.
///</summary>
public class Trigger : MonoBehaviour, ITrigger
{
    [Tooltip("Give the trigger an integer id that can be read by triggerable objects")]
    public int id;

    [Tooltip("The list of triggerables this trigger affects")]
    public List<Triggerable> triggerables;

    private ITrigger iTrigger;

    private void Awake()
    {
        iTrigger = GetComponent<ITrigger>();
    }

    public void Add(Triggerable addedTrigger)
    {
        if(triggerables != null && !triggerables.Contains(addedTrigger))
        {
            triggerables.Add(addedTrigger);
        }
    }

    public void Remove(Triggerable removedTrigger)
    {
        if(triggerables != null && triggerables.Contains(removedTrigger))
        {
            triggerables.Remove(removedTrigger);
        }
    }

    public void Notify()
    {
        if(triggerables != null)
        {
            foreach(Triggerable triggerable in triggerables)
            {
                if(triggerable != null)
                {
                    triggerable.OnNotify(id);
                }
            }
        }
    }
}
