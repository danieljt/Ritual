using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Class responsible for getting trigger notifications and sending them to 
/// other triggerables. By inheriting from this class, you ca create code locks
/// and other mecanisms for communicating with triggerables.
///</summary>
public class TriggerRouter : Triggerable, ITrigger
{
    public int id;
    public List<Triggerable> triggerables;

    private ITrigger iTrigger;

    private void Awake()
    {
        iTrigger = GetComponent<ITrigger>();
    }

    public override void OnNotify(int id)
    {
        Notify();
    }

    public void Add(Triggerable newTriggerable)
    {
        if(!triggerables.Contains(newTriggerable))
        {
            triggerables.Add(newTriggerable);
        }
    } 

    public void Remove(Triggerable oldTriggerable)
    {
        if(triggerables.Contains(oldTriggerable))
        {
            triggerables.Remove(oldTriggerable);
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
