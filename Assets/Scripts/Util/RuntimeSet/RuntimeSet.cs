using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// A runtimeset defines a scriptable container asset for storing refrences to objects that can be
/// used in different situations. It encapsulates a list structure and voids the need for 
/// multiple different singleton classes or direct refrences between triggers and triggerables. 
/// In many ways we can say that the runtimeset acts as a mediator as well. 
/// Inherit from this class to specify the objects you want in your lists.
///</summary>
public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();

    public void Initialize()
    {
        items.Clear();
    }

    public void Add(T newItem)
    {
        if(!items.Contains(newItem))
        {
            items.Add(newItem);
        }
    }

    public void Remove(T oldItem)
    {
        if(items.Contains(oldItem))
        {
            items.Remove(oldItem);
        }
    }

    public T Get(int index)
    {
        return items[index];
    }

    public List<T> Items
    {
        get{return items;}
    }
}
